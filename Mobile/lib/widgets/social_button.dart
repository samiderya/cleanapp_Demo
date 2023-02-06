import 'package:flutter/material.dart';

class SocialButton extends StatelessWidget {
  final Function onTap;
  final AssetImage logo;

  const SocialButton(
      {Key key,
        this.onTap,
        this.logo,
        })
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
        onTap: this.onTap,
        child: Container(
          height: 60.0,
          width: 60.0,
      decoration: BoxDecoration(
        shape: BoxShape.circle,
        color: Colors.white,
        boxShadow: [
          BoxShadow(
              color: Colors.black26,
            offset: Offset(0,2),
            blurRadius: 6.0,
          )
        ],
        image: DecorationImage(
          image: this.logo,
        )
      ),
        ),

    );
  }
}
