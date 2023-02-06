
import 'package:flutter/material.dart';

import 'colors.dart';

abstract class TextStyles {
  static TextStyle get header{
    return TextStyle(color:AppColors.darkgray,fontSize: 20.0,fontWeight: FontWeight.bold);
  }

  static TextStyle get body{
    return TextStyle(color:AppColors.darkgray,fontSize: 16.0);
  }

  static TextStyle get error{
    return TextStyle(color:AppColors.red,fontSize: 12.0);
  }

  static TextStyle get suggestion{
    return TextStyle(color:AppColors.primaryColor,fontSize: 16.0);
  }

  static TextStyle get content{
    return TextStyle(fontSize: 22.0);
  }

  static TextStyle get navTitle{
    return TextStyle(color:AppColors.lightblue,fontWeight: FontWeight.bold);
  }

  static TextStyle get buttonTextLight{
    return TextStyle(color: Colors.white,fontSize: 17.0,fontWeight: FontWeight.bold);
  }

  static TextStyle get subTitle{
    return TextStyle(color: Colors.blueGrey,fontSize: 16.0,fontWeight: FontWeight.w400,
    );
  }
  static TextStyle get subTitleLink{
    return  TextStyle(
      color: Colors.blueGrey,
      fontSize: 16.0,
      fontWeight: FontWeight.bold,
    );
  }
}
