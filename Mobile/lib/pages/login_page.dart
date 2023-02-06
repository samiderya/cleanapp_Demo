import 'dart:async';
import 'dart:io';

import 'package:cleaner_app/blocs/auth_bloc.dart';
import 'package:cleaner_app/models/user.dart';
import 'package:cleaner_app/styles/base.dart';
import 'package:cleaner_app/styles/colors.dart';
import 'package:cleaner_app/styles/text.dart';
import 'package:cleaner_app/widgets/alerts.dart';
import 'package:cleaner_app/widgets/button.dart';
import 'package:cleaner_app/widgets/social_button.dart';
import 'package:cleaner_app/widgets/textfield.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class LoginPage extends StatefulWidget {
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  StreamSubscription _userSubscription;
  StreamSubscription _errorMessageSubscription;

  @override
  void initState() {
    final authBloc = Provider.of<AuthBloc>(context, listen: false);
    _userSubscription = authBloc.user.listen((user) {
      if (user != null && user.isActive==true) {
        Navigator.of(context).pushNamed("/main_page");
      }
    }
    );

    _errorMessageSubscription = authBloc.errorMessage.listen((errorMessage) {
      if(errorMessage!=""){
        AppAlerts.showErrorDialog(Platform.isIOS,context, errorMessage).then((_) => authBloc.clearErrorMessage());
      }
    }
    );
    super.initState();
  }

  @override
  void dispose() {
    _userSubscription.cancel();
    _errorMessageSubscription.cancel();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final authBloc = Provider.of<AuthBloc>(context,listen: false);
    return Scaffold(
       body: CustomScrollView(
        slivers: <Widget>[
          SliverList(
            delegate: SliverChildListDelegate(
              [
                Padding(
                  padding: BaseStyles.scaffoldPadding,
                  child: Container(
                    decoration: BaseStyles.scaffoldBoxDecoration(hasLogo: true),
                    child: Column(
                      children: <Widget>[
                        Padding(
                          padding: const EdgeInsets.only(top: 180.0),
                          child: StreamBuilder<String>(
                              stream: authBloc.email,
                              builder: (context, snapshot) {
                                return AppTextField(
                                  isIOS: Platform.isIOS,
                                  hintText: "E-Mail",
                                  cupertinoIcon: CupertinoIcons.mail,
                                  materialIcon: Icons.mail,
                                  textInputType: TextInputType.emailAddress,
                                  errorText: snapshot.error,
                                  onChanged: authBloc.changeEmail,
                                );
                              }
                          ),
                        ),
                        StreamBuilder<String>(
                            stream: authBloc.password,
                            builder: (context, snapshot) {
                              return AppTextField(
                                isIOS: Platform.isIOS,
                                hintText: "Password",
                                obscureText: true,
                                cupertinoIcon: CupertinoIcons.lock,
                                materialIcon: Icons.lock,
                                textInputType: TextInputType.visiblePassword,
                                errorText: snapshot.error,
                                onChanged: authBloc.changePassword,
                              );
                            }
                        ),
                        Padding(
                          padding: const EdgeInsets.only(left: 16, right: 24,),
                          child: Align(
                            alignment: Alignment.topRight,
                            child: FlatButton(
                              onPressed: () {
                                //forgot password screen
                              },
                               textColor: AppColors.lightblue,
                              child: Text('Forgot Password?'),
                            ),
                          ),
                        ),
                        Padding(
                            padding: BaseStyles.listPadding,
                            child: GestureDetector(
                              onTap: () =>Navigator.of(context).pushNamed("/register_user_page"),
                              child: RichText(
                                text: TextSpan(
                                  children: [
                                    TextSpan(
                                      text: "Don\'t have an Account? ",
                                      style: TextStyles.subTitle,
                                    ),
                                    TextSpan(
                                      text: "Sign Up",
                                      style: TextStyles.subTitleLink,
                                    ),
                                  ],
                                ),
                              ),
                            )),

                        StreamBuilder<bool>(
                            stream: authBloc.isValid,
                            builder: (context, snapshot) {
                              return AppButton(
                                buttonText: 'Login',
                                buttonType: (snapshot.data == true)
                                    ? ButtonType.Primary
                                    : ButtonType.Disabled,
                                onPressed: authBloc.loginEmail,
                              );
                            }),

                        Padding(
                            padding: BaseStyles.listPadding,
                            child: Column(
                              children: <Widget>[
                                Text(
                                  '-OR-',
                                  style: TextStyle(
                                      color: Colors.blueGrey,
                                      fontWeight: FontWeight.w400),
                                ),
                                Padding(
                                  padding: BaseStyles.listPadding,
                                  child: Text(
                                    'Sign in with',
                                    style: TextStyle(
                                        color: Colors.blueGrey,
                                        fontWeight: FontWeight.w400),
                                  ),
                                )
                              ],
                            )),
                        Padding(
                          padding: BaseStyles.listPadding,
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                            children: <Widget>[
                              SocialButton(
                                onTap: () => print("Login with facebook"),
                                logo: AssetImage("assets/images/fbLogo.png"),
                              ),
                              StreamBuilder<ApplicationUser>(
                                stream: authBloc.user,
                                builder: (context, snapshot) {
                                  return SocialButton(
                                    onTap: authBloc.loginByGmail,
                                    logo:
                                        AssetImage("assets/images/googleLogo.png"),
                                  );
                                }
                              ),
                              SocialButton(
                                onTap: () => print("Login with google"),
                                logo:
                                    AssetImage("assets/images/twitterLogo.jpg"),
                              )
                            ],
                          ),
                        ),
                        SizedBox(height: 30,),
                      ],
                    ),
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
