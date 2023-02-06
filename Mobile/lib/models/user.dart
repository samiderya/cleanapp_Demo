import 'dart:convert';

import 'package:cleaner_app/models/enums/login_type.dart';
import 'package:google_sign_in/google_sign_in.dart';

import 'enums/user_type.dart';

ApplicationUser applicationUserFromJson(String str)=>ApplicationUser.fromJson(json.decode(str));
String applicationUserToJson(ApplicationUser user)=>json.encode(user.toJson());

class ApplicationUser {
  int id;
  String firstName;
  String lastName;
  String email;
  String password;
  String phoneNo;
  UserType userType;
  LoginType loginType;
  int roleid;
  String profilePicturePath;
  String uid;
  DateTime lastLogin;
  bool isLoggedIn;
  String token;
  int createdBy;
  DateTime createdAt;
  bool isActive;

  ApplicationUser({
    this.id,
    this.firstName,
    this.lastName,
    this.email,
    this.password,
    this.phoneNo,
    this.userType,
    this.loginType,
    this.roleid,
    this.profilePicturePath,
    this.uid,
    this.lastLogin,
    this.isLoggedIn,
    this.token,
    this.createdBy,
    this.createdAt,
    this.isActive,
  });

 factory ApplicationUser.fromGoogle(GoogleSignInAccount account,Map<String, dynamic> idMap)=>ApplicationUser(
    id: 0,
    email:account.email,
    firstName: idMap["given_name"],
    lastName: idMap["family_name"],
    loginType: LoginType.google,
    uid: account.id.toString(),
    isLoggedIn:true,
    isActive: true,
    profilePicturePath: account.photoUrl,
  );



  factory ApplicationUser.fromJson(Map<String, dynamic> json) => ApplicationUser(
    id: json["id"],
    firstName: json["first_name"],
    lastName: json["last_name"],
    email: json["email"],
    password: json["password"],
    phoneNo: json["phone_no"],
    userType: userTypeFromInt(json["user_typeid"]),
    loginType: loginTypeFromInt(json["login_typeid"]),
    roleid: json["roleid"],
    profilePicturePath: json["profile_picture_path"],
    uid: json["uid"],
    lastLogin: DateTime.parse(json["lastLogin"]),
    isLoggedIn: (json["isLoggedIn"]==1)?true:false,
    token: json["token"],
    createdBy: json["created_by"],
    createdAt: DateTime.parse(json["created_at"]),
    isActive:(json["is_active"]==0)?false:true,
  );




   Map<dynamic, dynamic> toJson() => {
   "first_name": firstName,
    "last_name": lastName,
    "email": email,
    "phone_no": phoneNo,
    "user_typeid": userType.value.toString(),
    "login_typeid": loginType.value.toString(),
    "imgUrl": profilePicturePath,
    "uid": uid,
    "isLoggedIn": isLoggedIn,
    "token": token,
    "is_active": isActive,
  };

 }
