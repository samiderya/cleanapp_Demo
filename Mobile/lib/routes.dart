
import 'package:cleaner_app/pages/filter_agent_page.dart';
import 'package:cleaner_app/pages/login_page.dart';
import 'package:cleaner_app/pages/main_page.dart';
import 'package:cleaner_app/pages/order_summary_page.dart';
import 'package:cleaner_app/pages/payment_page.dart';
import 'package:cleaner_app/pages/register_user_page.dart';
import 'package:cleaner_app/pages/select_service_page.dart';
import 'package:cleaner_app/widgets/agent_filter_view.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

abstract class Routes{
  static MaterialPageRoute materialRoute(RouteSettings settings){
    switch(settings.name){
      case "/filter_agent_page":
        return MaterialPageRoute(builder: (context)=>FilterAgentPage());

      case "/filter_agent_view":
        return MaterialPageRoute(builder: (context)=>AgentFilterView(),fullscreenDialog: true);

      case "/login_page":
        return MaterialPageRoute(builder: (context)=>LoginPage());

      case "/main_page":
        return MaterialPageRoute(builder: (context)=>MainPage());

      case "/order_summary_page":
        return MaterialPageRoute(builder: (context)=>OrderSummaryPage());

      case "/payment_page":
        return MaterialPageRoute(builder: (context)=>PaymentPage());

      case "/register_user_page":
        return MaterialPageRoute(builder: (context)=>RegisterUserPage());

      case "/select_service_page":
        return MaterialPageRoute(builder: (context)=>SelectServicePage());

      default:
       return MaterialPageRoute(builder: (context)=>MainPage());

    }
  }

  static CupertinoPageRoute cupertinoRoute(RouteSettings settings){
    switch(settings.name){
      case "/filter_agent_page":
        return CupertinoPageRoute(builder: (context)=>FilterAgentPage());

        case "/filter_agent_view":
        return CupertinoPageRoute(builder: (context)=>AgentFilterView(),fullscreenDialog: true);

      case "/login_page":
        return CupertinoPageRoute(builder: (context)=>LoginPage());

      case "/main_page":
        return CupertinoPageRoute(builder: (context)=>MainPage());

      case "/order_summary_page":
        return CupertinoPageRoute(builder: (context)=>OrderSummaryPage());

      case "/payment_page":
        return CupertinoPageRoute(builder: (context)=>PaymentPage());

      case "/register_user_page":
        return CupertinoPageRoute(builder: (context)=>RegisterUserPage());

      case "/select_service_page":
        return CupertinoPageRoute(builder: (context)=>SelectServicePage());

      default:
       return CupertinoPageRoute(builder: (context)=>MainPage());
    }
  }
}