import 'package:cleaner_app/api/data.dart';
import 'package:cleaner_app/blocs/cleaning_details_bloc.dart';
import 'package:cleaner_app/models/cleaning_details.dart';
import 'package:cleaner_app/styles/base.dart';
import 'package:cleaner_app/styles/colors.dart';
import 'package:cleaner_app/widgets/calendar_popup_view.dart';
import 'package:cleaner_app/widgets/slider_view.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

class SelectServicePage extends StatefulWidget {


  const SelectServicePage({Key key}) : super(key: key);

  @override
  _SelectServicePageState createState() => _SelectServicePageState();
}

class _SelectServicePageState extends State<SelectServicePage> {
  int numberofEmployees = 20;
  double totalHours = 40.0;
  DateTime startDate = DateTime.now();
  DateTime endDate = DateTime.now().add(const Duration(days: 5));


  @override
  Widget build(BuildContext context) {
    final cleaningDetailsBloc= Provider.of<CleaningDetailsBloc>(context, listen: false);
    print("aaaaaaaaaaaaa:${cleaningDetailsBloc?.getAgent()?.agentName}");

    return Scaffold(
      body: Column(
        children: <Widget>[
          Expanded(
            child: SingleChildScrollView(
                child:Padding(
                  padding: BaseStyles.scaffoldPadding,
                  child: StreamBuilder<CleaningDetails>(
                    stream: cleaningDetailsBloc.cleaningDetails,
                    builder: (context, snapshot) {
                      return snapshot.hasData==true?
                       Container(
                        decoration: BaseStyles.scaffoldBoxDecoration(hasLogo: false),
                        child: Column(
                          children: <Widget>[
                            Padding(
                             padding: BaseStyles.listPadding,
                              child: Column(
                                mainAxisAlignment: MainAxisAlignment.center,
                                crossAxisAlignment: CrossAxisAlignment.center,
                                children: <Widget>[

                              Image.network(
                              "$IP_ADDRESS/uploads/${snapshot.data.agent.imgUrl}",
                                fit: BoxFit.fill,
                              ),

                                  Padding(padding: BaseStyles.listPadding,
                                    child: Text(
                                      '${snapshot.data.agent.agentName}',
                                      textAlign: TextAlign.center,
                                      style: TextStyle(
                                          fontFamily: 'Roboto',
                                          fontWeight: FontWeight.w500,
                                          fontSize: 24,
                                          letterSpacing: -0.1,
                                          color: Color(0xFF253840)),
                                    ),
                                  ),
                                ],
                              ),
                            ),
                            Padding(
                              padding: BaseStyles.listPadding,
                              child: BaseStyles.divider(),
                            ),
                            dueDateFilter(),
                            BaseStyles.divider(),
                            totalHoursUI(cleaningDetailsBloc),
                            BaseStyles.divider(),
                            numberofEmployeesUI(cleaningDetailsBloc),
                            BaseStyles.divider(),
                            typeOfServiceUI()
                          ],
                        ),
                      ):Container();
                    }
                  ),
                ),
              ),
          ),
          const Divider(
            height: 1,
          ),
          Padding(
            padding: const EdgeInsets.only(
                left: 16, right: 16, bottom: 16, top: 8),
            child: Container(
              height: 48,
              decoration: BoxDecoration(
                color: AppColors.primaryColor,
                borderRadius: const BorderRadius.all(Radius.circular(24.0)),
                boxShadow: <BoxShadow>[
                  BoxShadow(
                    color: Colors.grey.withOpacity(0.6),
                    blurRadius: 8,
                    offset: const Offset(4, 4),
                  ),
                ],
              ),
              child: InkWell(
                borderRadius: const BorderRadius.all(Radius.circular(24.0)),
                highlightColor: Colors.transparent,
                onTap: () {
                  Navigator.of(context).pushNamed("/order_summary_page");
                },
                child: Center(
                  child: Text(
                    'Apply',
                    style: TextStyle(
                        fontWeight: FontWeight.w500,
                        fontSize: 18,
                        color: Colors.white),
                  ),
                ),
              ),
            ),
          )
        ],
      ),


    );


  }

  Widget typeOfServiceUI() {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Padding(
          padding:
          const EdgeInsets.only(left: 16, right: 16, top: 16, bottom: 8),
          child: Text(
            'Type of Service',
            textAlign: TextAlign.left,
            style: TextStyle(
                color: Colors.grey,
                fontSize: MediaQuery.of(context).size.width > 360 ? 18 : 16,
                fontWeight: FontWeight.normal),
          ),
        ),
        Padding(
          padding: const EdgeInsets.only(right: 16, left: 16),
          child: Column(
            children: getAgentTypesList(),
          ),
        ),
        const SizedBox(
          height: 8,
        ),
      ],
    );
  }

  List<Widget> getAgentTypesList() {
    final List<Widget> noList = <Widget>[];
    for (int i = 0; i < AgentServiceType.serviceTypes.length; i++) {
      final AgentServiceType date = AgentServiceType.serviceTypes[i];
      noList.add(
        Material(
          color: Colors.transparent,
          child: InkWell(
            borderRadius: const BorderRadius.all(Radius.circular(4.0)),
            onTap: () {
              setState(() {
                AgentServiceType.serviceTypes[i].isSelected = !AgentServiceType.serviceTypes[i].isSelected;

              });
            },
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Row(
                children: <Widget>[
                  Expanded(
                    child: Text(
                      date.title,
                      style: TextStyle(color: Colors.black),
                    ),
                  ),
                  CupertinoSwitch(
                    activeColor: date.isSelected
                        ? AppColors.primaryColor
                        : Colors.grey.withOpacity(0.6),
                    onChanged: (bool value) {
                      setState(() {
                        print("dddddd");

                        AgentServiceType.serviceTypes.forEach((element) {
                          element.isSelected=!element.isSelected;
                        });
                      });
                    },
                    value: date.isSelected,
                  ),
                ],
              ),
            ),
          ),
        ),
      );
      if (i == 0) {
        noList.add(const Divider(
          height: 1,
        ));
      }
    }
    return noList;
  }

  Widget dueDateFilter() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Padding(
          padding: const EdgeInsets.all(16.0),
          child: getTimeDateUI(),
        )

      ],
    );
  }

  Widget serviceFilter() {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Padding(
          padding:
          const EdgeInsets.only(left: 16, right: 16, top: 16, bottom: 8),
          child: Text(
            'Services',
            textAlign: TextAlign.left,
            style: TextStyle(
                color: Colors.grey,
                fontSize: MediaQuery.of(context).size.width > 360 ? 18 : 16,
                fontWeight: FontWeight.normal),
          ),
        ),

      ],
    );
  }

  Widget numberofEmployeesUI(CleaningDetailsBloc cleaningDetailsBloc) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Padding(
          padding:BaseStyles.listPadding,
          child: Text(
            'Number of employees',
            textAlign: TextAlign.left,
            style: TextStyle(
                color: Colors.grey,
                fontSize: MediaQuery.of(context).size.width > 360 ? 18 : 16,
                fontWeight: FontWeight.normal),
          ),
        ),
        SliderTheme(
          data: SliderThemeData(
            overlayColor: AppColors.primaryColor,
            valueIndicatorColor: AppColors.primaryColor,
            thumbShape: CustomThumbShape(),
          ),
          child: Slider(
            value: numberofEmployees.roundToDouble(),
            min: 0,
            max: 30,
            label: "$numberofEmployees",
            activeColor: AppColors.primaryColor,
            inactiveColor: Colors.grey.withOpacity(0.4),
            onChanged: (newValue){
              setState(() {
                numberofEmployees=newValue.toInt();
                cleaningDetailsBloc.setTotalEmployee(numberofEmployees);
              });
            },
            divisions: 30,

          ),
        ),
        const SizedBox(
          height: 8,
        ),
      ],
    );
  }
  Widget totalHoursUI(CleaningDetailsBloc cleaningDetailsBloc) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Padding(
          padding:BaseStyles.listPadding,
          child: Text('Total hours(max)',
            textAlign: TextAlign.left,
            style: TextStyle(
                color: Colors.grey,
                fontSize: MediaQuery.of(context).size.width > 360 ? 18 : 16,
                fontWeight: FontWeight.normal),
          ),
        ),
        SliderTheme(
          data: SliderThemeData(
            overlayColor: AppColors.primaryColor,
              valueIndicatorColor: AppColors.primaryColor,
              thumbShape: CustomThumbShape(),
          ),
          child: Slider(
            value: totalHours,
            min: 0,
            max: 40,
            label: "$totalHours",
            activeColor: AppColors.primaryColor,
            inactiveColor: Colors.grey.withOpacity(0.4),
            onChanged: (newValue){
              setState(() {
                totalHours=newValue;
                cleaningDetailsBloc.setTotalHours(totalHours);
              });
            },
            divisions: 40,

          ),
        ),
        const SizedBox(
          height: 8,
        ),
      ],
    );
  }

  Widget getTimeDateUI() {
    return Row(
      children: <Widget>[
        Expanded(
          child: Row(
            children: <Widget>[
              Material(
                color: Colors.transparent,
                child: InkWell(
                  focusColor: Colors.transparent,
                  highlightColor: Colors.transparent,
                  hoverColor: Colors.transparent,
                  splashColor: Colors.grey.withOpacity(0.2),
                  borderRadius: const BorderRadius.all(
                    Radius.circular(4.0),
                  ),
                  onTap: () {
                    FocusScope.of(context).requestFocus(FocusNode());
                    // setState(() {
                    //   isDatePopupOpen = true;
                    // });
                    showCalendarDialog(context: context);
                  },
                  child: Column(
                    children: [
                      Text(
                        'Due Date',
                        textAlign: TextAlign.left,
                        style: TextStyle(
                            color: Colors.grey,
                            fontSize: MediaQuery.of(context).size.width > 360 ? 18 : 16,
                            fontWeight: FontWeight.normal),
                      ),

                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
        Padding(
          padding: const EdgeInsets.only(right: 8),
          child: Container(
            width: 1,
            height: 42,
            color: Colors.grey.withOpacity(0.8),
          ),
        ),
        Expanded(
          child: Row(
            children: <Widget>[
              Material(
                color: Colors.transparent,
                child: InkWell(
                  focusColor: Colors.transparent,
                  highlightColor: Colors.transparent,
                  hoverColor: Colors.transparent,
                  splashColor: Colors.grey.withOpacity(0.2),
                  borderRadius: const BorderRadius.all(
                    Radius.circular(4.0),
                  ),
                  onTap: () {
                    FocusScope.of(context).requestFocus(FocusNode());
                    showCalendarDialog(context: context);
                  },
                  child: Padding(
                    padding: const EdgeInsets.only(
                        left: 8, right: 8, top: 4, bottom: 4),
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Text('${DateFormat("dd, MMM").format(startDate)} - ${DateFormat("dd, MMM").format(endDate)}',
                          style: TextStyle(
                            fontSize: 12,
                          ),
                        ),

                      ],
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ],
    );
  }

  void showCalendarDialog({BuildContext context}) {
    showDialog<dynamic>(
      context: context,
      builder: (BuildContext context) => CalendarPopupView(
        barrierDismissible: true,
        minimumDate: DateTime.now(),
        //  maximumDate: DateTime(DateTime.now().year, DateTime.now().month, DateTime.now().day + 10),
        initialEndDate: endDate,
        initialStartDate: startDate,
        onApplyClick: (DateTime startData, DateTime endData) {
          setState(() {
            if (startData != null && endData != null) {
              startDate = startData;
              endDate = endData;
            }
          });
        },
        onCancelClick: () {},
      ),
    );
  }



}
