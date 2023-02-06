import 'package:cleaner_app/api/data.dart';
import 'package:cleaner_app/blocs/auth_bloc.dart';
import 'package:cleaner_app/blocs/cleaning_details_bloc.dart';
import 'package:cleaner_app/blocs/cleaning_type_bloc.dart';
import 'package:cleaner_app/models/cleaning_type.dart';
import 'package:cleaner_app/models/user.dart';
import 'package:cleaner_app/styles/colors.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class MainPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final cleaningTypeBloc = Provider.of<CleaningTypeBloc>(context, listen: false);
    cleaningTypeBloc.loadCleaningTypes();
    final authBloc = Provider.of<AuthBloc>(context, listen: false);
    authBloc.email.listen((data) {
      print("user:$data");
    });

    _buildMenuItem(CleaningType cleaningType) {
     return  Padding(
        padding: const EdgeInsets.all(8.0),
        child: GestureDetector(
          onTap:  () {
            final cleaningDetailsBloc=Provider.of<CleaningDetailsBloc>(context,listen: false);
            cleaningDetailsBloc.setCleaningType(cleaningType);
            Navigator.of(context).pushNamed("/filter_agent_page");
      },

          child: Container(
              decoration: BoxDecoration(
              borderRadius: const BorderRadius.all(Radius.circular(16.0)),
              boxShadow: <BoxShadow>[
                BoxShadow(
                  color: Colors.grey.withOpacity(0.6),
                  offset: const Offset(4, 4),
                  blurRadius: 16,
                ),
              ],
            ),
            child: ClipRRect(
              borderRadius: const BorderRadius.all(Radius.circular(16.0)),
              child: Stack(
                children: <Widget>[
                  Column(
                    children: <Widget>[
                      AspectRatio(
                        aspectRatio: 1.4,
                        child:
                        Image.network(
                          "$IP_ADDRESS/uploads/${cleaningType.imgPath}",
                          fit: BoxFit.fill,
                        ),
                      ),
                      Container(
                        decoration: BoxDecoration(
                          color: AppColors.backgroundColor,
                          borderRadius: const BorderRadius.only( bottomLeft: Radius.circular(16.0),bottomRight: Radius.circular(16.0)),
                          boxShadow: <BoxShadow>[
                            BoxShadow(
                              color: Colors.grey.withOpacity(0.6),
                              offset: const Offset(4, 4),
                              blurRadius: 16,
                            ),
                          ],
                        ),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          crossAxisAlignment: CrossAxisAlignment.start,

                          children: <Widget>[
                            Expanded(
                              child: Padding(
                                padding: const EdgeInsets.only(
                                    left: 16, top: 8, bottom: 8),
                                child: Row(
                                  crossAxisAlignment: CrossAxisAlignment.center,
                                  mainAxisAlignment: MainAxisAlignment.start,
                                  children: <Widget>[
                                    Flexible(
                                      child: Text(
                                        cleaningType.cleaningType,
                                        overflow: TextOverflow.ellipsis,
                                        style: TextStyle(
                                            fontSize: 12,
                                            color: Colors.red.withOpacity(0.8)),
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),

                ],
              ),
            ),
          ),
        ),
      );
    }

    return Scaffold(
      // appBar: AppBar(title:Text("Services")),
      body: Column(
        children: <Widget>[
          Expanded(
            child: StreamBuilder<List<CleaningType>>(
              stream: cleaningTypeBloc.cleaningTypes,
              builder: (context, snapshot) {
                if(!snapshot.hasData) return Center(child: CircularProgressIndicator(),);
                return GridView.count(
                  //padding: EdgeInsets.all(10.0),
                  crossAxisCount: 2,
                  children: List.generate(snapshot.data.length, (index) {
                    return _buildMenuItem(snapshot.data[index]);
                  }),
                );
              }
            ),
          ),
        ],
      ),
    );
  }
}
