import 'package:cleaner_app/styles/base.dart';
import 'package:cleaner_app/styles/colors.dart';
import 'package:flutter/material.dart';

class OrderSummaryPage extends StatelessWidget {
  const OrderSummaryPage({Key key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: <Widget>[
          Expanded(
            child: SingleChildScrollView(
              child: Padding(
                padding: BaseStyles.listPadding,
                child: Container(
                  decoration: BaseStyles.scaffoldBoxDecoration(hasLogo: false),
                  child: Column(
                    children: <Widget>[
                      Padding(
                        padding: BaseStyles.listPadding,
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.center,
                          crossAxisAlignment: CrossAxisAlignment.center,
                          children: <Widget>[
                            Image(
                              image: AssetImage(
                                "assets/images/johns.png",
                              ),
                              height: 150.0,
                            ),
                            Padding(
                              padding: const EdgeInsets.only(
                                left: 4,
                                bottom: 28,
                                top: 16,
                              ),
                              child: Text(
                                'John\'s Cleaning Services',
                                textAlign: TextAlign.center,
                                style: TextStyle(
                                    fontFamily: 'Roboto',
                                    fontWeight: FontWeight.w500,
                                    fontSize: 24,
                                    letterSpacing: -0.1,
                                    color: Color(0xFF253840)),
                              ),
                            ),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              crossAxisAlignment: CrossAxisAlignment.center,
                              children: <Widget>[
                                Column(
                                  children: [
                                    Padding(
                                      padding: const EdgeInsets.only(
                                          left: 4, bottom: 3),
                                      child: Text(
                                        'Hourly rate(\$)',
                                        textAlign: TextAlign.center,
                                        style: TextStyle(
                                          fontFamily: 'Roboto',
                                          fontWeight: FontWeight.w600,
                                          fontSize: 20,
                                          color: Color(0xFF253840),
                                        ),
                                      ),
                                    ),
                                  ],
                                ),
                                Column(
                                  children: [
                                    Padding(
                                      padding: const EdgeInsets.only(
                                          left: 4, bottom: 3),
                                      child: Text(
                                        '300 \$',
                                        textAlign: TextAlign.center,
                                        style: TextStyle(
                                          fontFamily: 'Roboto',
                                          fontWeight: FontWeight.w600,
                                          fontSize: 20,
                                          color: Color(0xFF3A5160)
                                              .withOpacity(0.5),
                                        ),
                                      ),
                                    ),
                                  ],
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                      BaseStyles.divider(),
                      Padding(
                        padding: BaseStyles.listPadding,
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          crossAxisAlignment: CrossAxisAlignment.center,
                          children: <Widget>[
                            Column(
                              children: [
                                Padding(
                                  padding:
                                      const EdgeInsets.only(left: 4, bottom: 3),
                                  child: Text(
                                    'Total hours',
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.w600,
                                      fontSize: 20,
                                      color: Color(0xFF253840),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                            Column(
                              children: [
                                Padding(
                                  padding:
                                      const EdgeInsets.only(left: 4, bottom: 3),
                                  child: Text(
                                    '6 hrs',
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.w600,
                                      fontSize: 20,
                                      color: Color(0xFF3A5160).withOpacity(0.5),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                      BaseStyles.divider(),
                      Padding(
                        padding: BaseStyles.listPadding,
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          crossAxisAlignment: CrossAxisAlignment.center,
                          children: <Widget>[
                            Column(
                              children: [
                                Padding(
                                  padding:
                                      const EdgeInsets.only(left: 4, bottom: 3),
                                  child: Text(
                                    'Total amount',
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.w600,
                                      fontSize: 20,
                                      color: Color(0xFF253840),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                            Column(
                              children: [
                                Padding(
                                  padding:
                                      const EdgeInsets.only(left: 4, bottom: 3),
                                  child: Text(
                                    '1800 \$',
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.w600,
                                      fontSize: 20,
                                      color: Color(0xFF3A5160).withOpacity(0.5),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                      BaseStyles.divider(),
                      Padding(
                        padding: BaseStyles.listPadding,
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          crossAxisAlignment: CrossAxisAlignment.center,
                          children: <Widget>[
                            Column(
                              children: [
                                Padding(
                                  padding:
                                      const EdgeInsets.only(left: 4, bottom: 3),
                                  child: Text(
                                    'Package Type',
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.w600,
                                      fontSize: 20,
                                      color: Color(0xFF253840),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                            Column(
                              children: [
                                Padding(
                                  padding:
                                      const EdgeInsets.only(left: 4, bottom: 3),
                                  child: Text(
                                    'One Time',
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.w600,
                                      fontSize: 20,
                                      color: Color(0xFF3A5160).withOpacity(0.5),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                      BaseStyles.divider(),
                      Padding(
                        padding: BaseStyles.listPadding,
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          crossAxisAlignment: CrossAxisAlignment.center,
                          children: <Widget>[
                            Column(
                              children: [
                                Padding(
                                  padding:
                                      const EdgeInsets.only(left: 4, bottom: 3),
                                  child: Text(
                                    'Schedule',
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.w600,
                                      fontSize: 20,
                                      color: Color(0xFF253840),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                            Column(
                              children: [
                                Padding(
                                  padding:
                                      const EdgeInsets.only(left: 4, bottom: 3),
                                  child: Text(
                                    '12/10/2020',
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.w600,
                                      fontSize: 20,
                                      color: Color(0xFF3A5160).withOpacity(0.5),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                      BaseStyles.divider(),
                      Padding(
                        padding: BaseStyles.listPadding,
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          crossAxisAlignment: CrossAxisAlignment.center,
                          children: <Widget>[
                            Column(
                              children: [
                                Padding(
                                  padding:
                                      const EdgeInsets.only(left: 4, bottom: 3),
                                  child: Text(
                                    'Mobile',
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.w600,
                                      fontSize: 20,
                                      color: Color(0xFF253840),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                            Column(
                              children: [
                                Padding(
                                  padding:
                                      const EdgeInsets.only(left: 4, bottom: 3),
                                  child: Text(
                                    '+005464886',
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.w600,
                                      fontSize: 20,
                                      color: Color(0xFF3A5160).withOpacity(0.5),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
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
                  Navigator.of(context).pushNamed("/payment_page");
                },
                child: Center(
                  child: Text(
                    'Purchase',
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
}
