
import 'dart:io';

import 'package:cleaner_app/blocs/agents_bloc.dart';
import 'package:cleaner_app/blocs/cleaning_type_bloc.dart';
import 'package:cleaner_app/pages/login_page.dart';
import 'package:cleaner_app/pages/main_page.dart';
import 'package:cleaner_app/routes.dart';
import 'package:cleaner_app/styles/colors.dart';
import 'package:cleaner_app/styles/text.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:provider/provider.dart';

import 'blocs/auth_bloc.dart';
import 'blocs/cleaning_details_bloc.dart';

void main() async {


  runApp(MyApp());
}

class MyApp extends StatefulWidget {
  // This widget is the root of your application.
  @override
  _MyAppState createState() => _MyAppState();
}

  class _MyAppState extends State<MyApp> {
  final authBloc=AuthBloc();
  final cleaningTypeBloc=CleaningTypeBloc();
  final agentsBloc=AgentsBloc();
  final cleaningDetailsBloc=CleaningDetailsBloc();

  @override
  Widget build(BuildContext context) {

    SystemChrome.setSystemUIOverlayStyle(SystemUiOverlayStyle(
      statusBarColor: Colors.transparent,
    ));
    return MultiProvider(
        providers: [
          Provider(create: (context)=>authBloc,),
          Provider(create: (context)=> cleaningDetailsBloc),
          Provider(create: (context)=>cleaningTypeBloc),
          Provider(create: (context)=> agentsBloc),
          FutureProvider(create: (context)=> authBloc.isLoggedIn()),        ],
        child: PlatformApp());
  }

  @override
  void dispose() {
    authBloc.dispose();
    super.dispose();
  }
}

class PlatformApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var isLoggedIn=Provider.of<bool>(context);

    if(Platform.isIOS){
      return CupertinoApp(
          home: (isLoggedIn==null) ? loadingScreen(true)
              :(isLoggedIn==true) ? MainPage() : LoginPage(),
          debugShowCheckedModeBanner: false,
          onGenerateRoute: Routes.cupertinoRoute,
          theme:CupertinoThemeData(
              primaryColor: AppColors.primaryColor,
              textTheme: CupertinoTextThemeData(
                tabLabelTextStyle: TextStyles.subTitle,
              ),
              scaffoldBackgroundColor: AppColors.backgroundColor
          )
      );
    } else {
      return MaterialApp(
        home: LoginPage(),
        onGenerateRoute: Routes.materialRoute,
        debugShowCheckedModeBanner: false,
        theme: ThemeData(scaffoldBackgroundColor: Colors.white),
      );
    }
  }

  Widget loadingScreen(bool isIOS){
    return (isIOS) ? CupertinoPageScaffold(child: Center(child: CupertinoActivityIndicator(),),)
        : Scaffold(body: Center(child: CircularProgressIndicator(),),);
  }
}
