import 'dart:async';
import 'dart:io';

import 'package:cleaner_app/blocs/auth_bloc.dart';
import 'package:cleaner_app/styles/base.dart';
import 'package:cleaner_app/widgets/alerts.dart';
import 'package:cleaner_app/widgets/button.dart';
import 'package:cleaner_app/widgets/textfield.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class RegisterUserPage extends StatefulWidget {
  @override
  _RegisterUserPageState createState() => _RegisterUserPageState();
}

class _RegisterUserPageState extends State<RegisterUserPage> {
  StreamSubscription _userSubscription;
  StreamSubscription _errorMessageSubscription;

  @override
  void initState() {
    final authBloc = Provider.of<AuthBloc>(context, listen: false);
    _userSubscription = authBloc.user.listen((user) {
      if (user != null && user.isActive==true) {
        Navigator.pushReplacementNamed(context, "/main_page");
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
    final authBloc = Provider.of<AuthBloc>(context);

    return Scaffold(
      body: CustomScrollView(
        slivers: <Widget>[
          SliverList(
            delegate: SliverChildListDelegate([
              Padding(
                padding: BaseStyles.scaffoldPadding,
                child: Container(
                  decoration: BaseStyles.scaffoldBoxDecoration(hasLogo: true),
                  child: Column(
                    children: <Widget>[
                      Padding(
                        padding: const EdgeInsets.only(top: 180.0),
                        child: StreamBuilder<String>(
                            stream: authBloc.firstName,
                            builder: (context, snapshot) {
                              return AppTextField(
                                isIOS: Platform.isIOS,
                                hintText: "First Name",
                                cupertinoIcon: CupertinoIcons.person,
                                materialIcon: Icons.person,
                                textInputType: TextInputType.name,
                                errorText: snapshot.error,
                                onChanged: authBloc.changeFirstName,
                              );
                            }
                        ),
                      ),
                      StreamBuilder<String>(
                          stream: authBloc.lastName,
                          builder: (context, snapshot) {
                            return AppTextField(
                              isIOS: Platform.isIOS,
                              hintText: "Last Name",
                              cupertinoIcon: CupertinoIcons.person,
                              materialIcon: Icons.person,
                              textInputType: TextInputType.name,
                              errorText: snapshot.error,
                              onChanged: authBloc.changeLastName,
                            );
                          }
                      ),
                      StreamBuilder<String>(
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
                      StreamBuilder<String>(
                          stream: authBloc.phone,
                          builder: (context, snapshot) {
                            return AppTextField(
                              isIOS: Platform.isIOS,
                              hintText: "Phone",
                              cupertinoIcon: CupertinoIcons.phone,
                              materialIcon: Icons.phone,
                              textInputType: TextInputType.phone,
                              errorText: snapshot.error,
                              onChanged: authBloc.changePhone,
                            );
                          }
                      ),
                      Padding(
                        padding: const EdgeInsets.all(18.0),
                        child: TextField(
                          decoration: InputDecoration(
                            prefixIcon: Icon(Icons.location_on),
                            labelText: "Zip Code",
                            enabledBorder: OutlineInputBorder(
                              borderSide: BorderSide(
                                color: Colors.blue,
                              ),
                            ),
                            border: OutlineInputBorder(),
                          ),
                        ),
                      ),
                      StreamBuilder<bool>(
                          stream: authBloc.isValid,
                          builder: (context, snapshot) {
                            return AppButton(buttonText: "Register",
                              buttonType: (snapshot.data == true)
                                  ? ButtonType.Primary:ButtonType.Disabled,
                              onPressed: authBloc.signupEmail,
                            );
                          }
                      ),
                      Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Expanded(
                              child: Container(
                                height: 1,
                                color: Colors.grey,
                              ),
                            ),
                            Center(
                              child: Container(
                                  padding: EdgeInsets.all(10), child: Text("OR")),
                            ),
                            Expanded(
                              child: Container(
                                height: 1,
                                color: Colors.grey,
                              ),
                            ),
                          ],
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Container(
                              height: 60,
                              width: 60,
                              decoration: BoxDecoration(
                                  shape: BoxShape.circle,
                                  border: Border.all(
                                      color: Colors.black,
                                      width: 0.5
                                  )
                              ),
                              child: Container(
                                decoration: BoxDecoration(
                                    image: DecorationImage(
                                        image: AssetImage('assets/images/googleLogo.png')
                                    )
                                ),
                              ),
                            ),
                            SizedBox(width: 20,),
                            Container(
                              height: 60,
                              width: 60,
                              decoration: BoxDecoration(
                                  shape: BoxShape.circle,
                                  border: Border.all(
                                      color: Colors.black,
                                      width: 0.5
                                  )
                              ),
                              child: Container(
                                decoration: BoxDecoration(
                                    image: DecorationImage(
                                        image: AssetImage('assets/images/fbLogo.png')
                                    )
                                ),
                              ),
                            )
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
              ),

            ]),
          ),
        ],
      ),
    );
  }
}
