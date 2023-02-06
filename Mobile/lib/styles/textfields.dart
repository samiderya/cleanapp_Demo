
import 'package:cleaner_app/styles/text.dart';
import 'package:flutter/material.dart';

import 'base.dart';
import 'colors.dart';

abstract class TextFieldStyles {
  static double get textBoxHorizontal=> BaseStyles.listFieldsHorizontal;

  static double get textBoxVertical=> BaseStyles.listFieldsVertical;

  static Color get cursorColor=> AppColors.green;

  static TextStyle get placeholder=> TextStyles.suggestion;

  static TextStyle get text=> TextStyles.body;

  static TextStyle get body{
    return TextStyle(color:AppColors.darkgray,fontSize: 16.0);
  }

  static Widget iconPrefix(IconData icon)=> BaseStyles.iconPrefix(icon);

  static TextAlign get textAlign=> TextAlign.start;

  static BoxDecoration get cupertinoDecoration{
    return BoxDecoration(
      border: Border.all(color:AppColors.green,width: BaseStyles.borderWidth),
      borderRadius: BorderRadius.circular(BaseStyles.borderRadius),
    );
  }

  static BoxDecoration get cupertinoErrorDecoration{
    return BoxDecoration(
      border: Border.all(color:AppColors.red,width: BaseStyles.borderWidth),
      borderRadius: BorderRadius.circular(BaseStyles.borderRadius),
    );
  }


  static InputDecoration materialDecoration(String hintText,IconData icon,String errorText){
    return InputDecoration(
      labelText: hintText,
      labelStyle: TextFieldStyles.placeholder,
      border: InputBorder.none,
      errorText: errorText,
      errorStyle: TextStyles.error,
      focusedBorder: OutlineInputBorder(
        borderSide: BorderSide(color: AppColors.blue,
        ),
      ),
      errorBorder: OutlineInputBorder(
        borderSide: BorderSide(
          color: AppColors.red,
        ),
      ),
      focusedErrorBorder: OutlineInputBorder(
        borderSide: BorderSide(
          color: AppColors.lightblue,
          width: BaseStyles.borderWidth,
        ),
      ),
      enabledBorder: OutlineInputBorder(
        borderSide: BorderSide(
          color: AppColors.lightblue,
        ),

      ),
      prefixIcon: Icon(icon,color: AppColors.primaryColor,),
    );
  }

}