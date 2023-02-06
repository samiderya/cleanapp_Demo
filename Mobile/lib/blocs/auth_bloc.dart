
import 'dart:async';
import 'dart:convert';
import 'dart:io';

import 'package:cleaner_app/api/data.dart';
import 'package:cleaner_app/models/enums/user_type.dart';
import 'package:cleaner_app/models/location.dart';
import 'package:cleaner_app/models/user.dart';
import 'package:connectivity/connectivity.dart';
import 'package:flutter/services.dart';
import 'package:geolocator/geolocator.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';
import 'package:google_sign_in/google_sign_in.dart';
import 'package:rxdart/rxdart.dart';
import 'package:http/http.dart' as http;
import 'dart:convert' as convert;

final RegExp regExpEmail = RegExp(
    r'^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$');

class AuthBloc {
  final _firstName = BehaviorSubject<String>();
  final _lastName = BehaviorSubject<String>();
  final _email = BehaviorSubject<String>();
  final _password = BehaviorSubject<String>();
  final _phone = BehaviorSubject<String>();
  final _user =BehaviorSubject<ApplicationUser>();
  final _location =BehaviorSubject<Location>();
  final _errorMessage =BehaviorSubject<String>();

  Stream<String> get firstName => _firstName.stream;
  Stream<String> get lastName => _lastName.stream;
  Stream<String> get phone => _phone.stream;
  Stream<String> get email => _email.stream.transform(validateEmail);
  Stream<String> get password => _password.stream.transform(validatePassword);
  Stream<Location> get location => _location.stream;


  Stream<bool> get isValid =>
      CombineLatestStream.combine2(email, password, (email, password) => true);
  Stream<ApplicationUser> get user=>_user.stream;
  Stream<String> get errorMessage=>_errorMessage.stream;
  int get userId => _user.value.id;


  Function(String) get changeFirstName => _firstName.sink.add;
  Function(String) get changeLastName => _lastName.sink.add;
  Function(String) get changePhone => _phone.sink.add;
  Function(String) get changeEmail => _email.sink.add;
  Function(String) get changePassword => _password.sink.add;
  Function(Location) get changeLocation => _location.sink.add;

  dispose() {
    _firstName.close();
    _lastName.close();
    _phone.close();
    _email.close();
    _password.close();
    _user.close();
    _location.close();
    _errorMessage.close();
  }

  final validateEmail =
  StreamTransformer<String, String>.fromHandlers(handleData: (email, sink) {
    if (regExpEmail.hasMatch(email.trim())) {
      sink.add(email.trim());
    } else {
      sink.addError("Must be valid Email Address");
    }
  });

  final validatePassword = StreamTransformer<String, String>.fromHandlers(
      handleData: (password, sink) {
        if (password.length >= 2) {
          sink.add(password.trim());
        } else {
          sink.addError("2 Character minimum");
        }
      });

  signupEmail() async{
    try{/*
      UserCredential authResult= await _auth.createUserWithEmailAndPassword(email: _email.value.trim(),
          password: _password.value.trim());
      var user= ApplicationUser(userUID:authResult.user.uid,email:_email.value.trim());
      await _firestoreService.addUser(user);
      _user.sink.add(user);*/
    } catch(error){
      _errorMessage.sink.add(error.message);
    }
  }

     setLocation() async{
    try{
      var connectivityResult=await Connectivity().checkConnectivity();
      if(connectivityResult!=ConnectivityResult.mobile && connectivityResult!=ConnectivityResult.wifi )
      {
        return;
      }
      else{
        Position position=await Geolocator.getCurrentPosition(desiredAccuracy: LocationAccuracy.high);
        LatLng latLng=LatLng(position.latitude, position.longitude);
        Location location=Location(name: "", address: "", city: "", state: "", latLng: latLng);

        _location.sink.add(location);
        print("tttttttttt:$connectivityResult");
      }
    }
    catch(ex){
        print("hataaaaa:$ex");
    }
  }

  loginEmail() async{
    try{
      var url="$IP_ADDRESS/api/account/AuthenticateUser/${_email.value.trim()}/${_password.value.trim()}";
      var response=await http.get(url);
      var json=convert.jsonDecode(response.body);

      var user= ApplicationUser.fromJson(json["model"]);

      if(user.isActive==true) {
         _user.sink.add(user);
      }else{
        _errorMessage.sink.add("No user found.");
      }

    } catch (error){
      print("xxxxxx$error");
      _errorMessage.sink.add(error);
    }
  }

  loginByGmail() async{
    try{
      GoogleSignIn _googleSignIn=GoogleSignIn(
        scopes: ["profile","email"]
      );
      GoogleSignInAccount currentUser;
      currentUser= await _googleSignIn.signIn();
      final GoogleSignInAuthentication googleSignInAuthentication = await currentUser.authentication;
      final idToken = googleSignInAuthentication.idToken;
      Map<String, dynamic> idMap = parseJwt(idToken);
      var user= ApplicationUser.fromGoogle(currentUser,idMap);
      user.userType=UserType.customer;
      String body=applicationUserToJson(user);
      var url="$IP_ADDRESS/api/account/Register";
      var json;
      await http.post(url,body: body,
          headers:{HttpHeaders.acceptHeader:"application/json",
          HttpHeaders.contentTypeHeader:"application/json-patch+json"} )
          .then((response) {
        json=convert.jsonDecode(response.body);
      });
      user= ApplicationUser.fromJson(json["model"]);

     if(user.isActive==true) {
        _user.sink.add(user);
      }else{
        _errorMessage.sink.add("No user found.");
      }

    } on PlatformException catch (error) {
        _errorMessage.sink.add(error.message);
    }
    catch (error){
      print("xxxxxx$error");
      _errorMessage.sink.add(error);
    }

  }

  static Map<String, dynamic> parseJwt(String token) {
    // validate token
    if (token == null) return null;
    final List<String> parts = token.split('.');
    if (parts.length != 3) {
      return null;
    }
    // retrieve token payload
    final String payload = parts[1];
    final String normalized = base64Url.normalize(payload);
    final String resp = utf8.decode(base64Url.decode(normalized));
    // convert to Map
    final payloadMap = json.decode(resp);
    if (payloadMap is! Map<String, dynamic>) {
      return null;
    }
    print(payloadMap);
    return payloadMap;
  }

  Future<bool> isLoggedIn() async {
   /* var firebaseUser= _auth.currentUser;
    if(firebaseUser==null) return false;
    var user=await _firestoreService.fetchUser(firebaseUser.uid);
    if(user==null) return false;
    _user.sink.add(user);*/
    return true;
  }

  logout() async{
    //await _auth.signOut();
    _user.sink.add(null);
  }

  clearErrorMessage(){
    _errorMessage.sink.add("");
  }
}
