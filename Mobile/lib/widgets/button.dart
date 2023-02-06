import 'package:cleaner_app/styles/base.dart';
import 'package:cleaner_app/styles/buttons.dart';
import 'package:cleaner_app/styles/colors.dart';
import 'package:cleaner_app/styles/text.dart';
import 'package:flutter/cupertino.dart';

class AppButton extends StatefulWidget {
  final String buttonText;
  final ButtonType buttonType;
  final void Function() onPressed;

  AppButton({
    @required this.buttonText,this.buttonType,this.onPressed
  });

  @override
  _AppButtonState createState() => _AppButtonState();
}

class _AppButtonState extends State<AppButton> {
  bool pressed=false;
  @override
  Widget build(BuildContext context) {
    TextStyle fontStyle;
    Color buttonColor;

    switch(widget.buttonType){

      case ButtonType.Green:
        fontStyle=TextStyles.buttonTextLight;
        buttonColor=AppColors.green;
        break;
      case ButtonType.Primary:
        fontStyle=TextStyles.buttonTextLight;
        buttonColor=AppColors.primaryColor;
        break;
      case ButtonType.Disabled:
        fontStyle=TextStyles.buttonTextLight;
        buttonColor=AppColors.darkgray;
        break;

      default:
        fontStyle=TextStyles.buttonTextLight;
        buttonColor=AppColors.lightblue;
        break;
    }

    return Padding(
      padding: EdgeInsets.only(
        top: (pressed) ? BaseStyles.listFieldsVertical + BaseStyles.animationOffset :BaseStyles.listFieldsVertical,
        bottom: (pressed) ? BaseStyles.listFieldsVertical - BaseStyles.animationOffset :BaseStyles.listFieldsVertical,
        left: BaseStyles.listFieldsHorizontal,
        right: BaseStyles.listFieldsHorizontal,

      ),
      child: AnimatedContainer(
        child: GestureDetector(
          child: Container(
            height: ButtonStyles.buttonHeight,
            width: MediaQuery.of(context).size.width,
            decoration: BoxDecoration(
              color: buttonColor,
              borderRadius: BorderRadius.circular(BaseStyles.borderRadius),
              boxShadow: (pressed) ? BaseStyles.boxShadowPressed : BaseStyles.boxShadow,
            ),

            child:Center(child: Text(widget.buttonText,style: fontStyle,),),
          ),
          onTapDown: (details){
            setState(() {
              if(widget.buttonType!=ButtonType.Disabled) pressed= !pressed;
            });
          },
          onTapUp: (details){
            setState(() {
              if(widget.buttonType!=ButtonType.Disabled) pressed= !pressed;
            });
          },
          onTap: (){
            if(widget.buttonType!=ButtonType.Disabled){
              widget.onPressed();
            }
          },
        ),
        duration: Duration(milliseconds: 20),
      ),
    );
  }
}

enum ButtonType {Orange,Disabled,Green,Primary}
