import 'package:flutter/material.dart';

import 'colors.dart';

abstract class BaseStyles {
  static double get borderRadius => 25.0;
  static double get borderWidth => 2.0;

  static double get listFieldsHorizontal=> 16.0;
  static double get listFieldsVertical=> 8.0;

  static double get animationOffset=> 2.0;

  static EdgeInsets get scaffoldPadding{
    return EdgeInsets.only(
        left: 24, right: 24, top: 26, bottom: 16);
  }

  static Widget divider(){
    return Padding(
      padding: const EdgeInsets.only(
          left: 24, right: 24, top: 8, bottom: 8),
      child: Container(
        height: 2,
        decoration: BoxDecoration(
          color: AppColors.divider,
          borderRadius:
          BorderRadius.all(Radius.circular(4.0)),
        ),
      ),
    );
  }

  static BoxDecoration scaffoldBoxDecoration({bool hasLogo}){
    return BoxDecoration(
      color: Colors.white,
      image: (hasLogo==true) ? DecorationImage(
          image: AssetImage("assets/images/logo.png"),
          alignment: Alignment.topCenter,
      ):null,
      borderRadius: BorderRadius.only(
          topLeft: Radius.circular(8.0),
          bottomLeft: Radius.circular(8.0),
          bottomRight: Radius.circular(8.0),
          topRight: Radius.circular(68.0)),
      boxShadow: <BoxShadow>[
        BoxShadow(
            color: Color(0xFF3A5160).withOpacity(0.2),
            offset: Offset(1.1, 1.1),
            blurRadius: 10.0),
      ],
    );
  }



  static EdgeInsets get listPadding{
    return EdgeInsets.only(
      top: 16,
      left: 16,
      right: 24,
    );
  }

  static List<BoxShadow> get boxShadow{
    return [
      BoxShadow(
        color:AppColors.darkgray.withOpacity(.5),
        offset: Offset(1.0,2.0),
        blurRadius: 2.0,
      )
    ];
  }

  static List<BoxShadow> get boxShadowPressed{
    return [
      BoxShadow(
        color:AppColors.darkgray.withOpacity(.5),
        offset: Offset(1.0,1.0),
        blurRadius: 1.0,
      )
    ];
  }

  static Widget iconPrefix(IconData icon){
    return Padding(padding: const EdgeInsets.only(left: 8.0),
      child: Icon(
        icon,
        size: 35.0,
        color: AppColors.lightblue,
      ),
    );
  }
}