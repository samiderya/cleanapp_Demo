
import 'package:cleaner_app/styles/colors.dart';
import 'package:flutter/material.dart';

class SliderView extends StatefulWidget{
  const SliderView({Key key, this.onChangedistValue, this.value,this.maxValue,this.firstText="",this.lastText=""})
      : super(key: key);

  final Function(double) onChangedistValue;
  final double value;
  final double maxValue;
  final String firstText;
  final String lastText;
  @override
  _SliderViewState createState() => _SliderViewState();
}

class _SliderViewState extends State<SliderView> {
  double maxValue = 40.0;
  double value=1.0;

  @override
  void initState() {
    maxValue = widget.maxValue;
    value=widget.value;
    print("maxValue:$maxValue");
    print("Value:$value");
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Column(
        children: <Widget>[
          SliderTheme(
            data: SliderThemeData(
              thumbShape: RoundSliderThumbShape(),
            ),
            child: Slider(
                        onChanged: (double value) {

                try {
                  widget.onChangedistValue(value);
                  print("xxx$value");
                  print("max$maxValue");
                } catch (_) {}
              },
              min: 0,
              max: maxValue ,
              activeColor: AppColors.primaryColor,
              inactiveColor: Colors.grey.withOpacity(0.4),
              divisions: 100,
              label: "$value",
              value: value,
            ),
          ),
        ],
      ),
    );
  }
}

class CustomThumbShape extends SliderComponentShape {
  static const double _thumbSize = 3.0;
  static const double _disabledThumbSize = 3.0;

  @override
  Size getPreferredSize(bool isEnabled, bool isDiscrete) {
    return isEnabled
        ? const Size.fromRadius(_thumbSize)
        : const Size.fromRadius(_disabledThumbSize);
  }

  static final Animatable<double> sizeTween = Tween<double>(
    begin: _disabledThumbSize,
    end: _thumbSize,
  );

  @override
  void paint(
      PaintingContext context,
      Offset thumbCenter, {
        Animation<double> activationAnimation,
        Animation<double> enableAnimation,
        bool isDiscrete,
        TextPainter labelPainter,
        RenderBox parentBox,
        Size sizeWithOverflow,
        SliderThemeData sliderTheme,
        TextDirection textDirection,
        double textScaleFactor,
        double value,
      }) {
    final Canvas canvas = context.canvas;
    final ColorTween colorTween = ColorTween(
      begin: sliderTheme.disabledThumbColor,
      end: sliderTheme.thumbColor,
    );
    canvas.drawPath(
        Path()
          ..addOval(Rect.fromPoints(
              Offset(thumbCenter.dx + 12, thumbCenter.dy + 12),
              Offset(thumbCenter.dx - 12, thumbCenter.dy - 12)))
          ..fillType = PathFillType.evenOdd,
        Paint()
          ..color = Colors.black.withOpacity(0.5)
          ..maskFilter =
          MaskFilter.blur(BlurStyle.normal, convertRadiusToSigma(8)));

    final Paint cPaint = Paint();
    cPaint..color = Colors.white;
    cPaint..strokeWidth = 14 / 2;
    canvas.drawCircle(Offset(thumbCenter.dx, thumbCenter.dy), 12, cPaint);
    cPaint..color = colorTween.evaluate(enableAnimation);
    canvas.drawCircle(Offset(thumbCenter.dx, thumbCenter.dy), 10, cPaint);
  }

  double convertRadiusToSigma(double radius) {
    return radius * 0.57735 + 0.5;
  }
}
