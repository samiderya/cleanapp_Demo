import 'package:cleaner_app/models/user.dart';

class Agent extends ApplicationUser{
  String agentName;
  String agentPhone;
  String agentEmail;
  String address;
  double latitude;
  double longitude;
  double rate;
  double star;
  dynamic pin;
  double mileRange;
  String imgUrl;


  Agent({
    this.agentName,
    this.agentPhone,
    this.agentEmail,
    this.address,
    this.latitude,
    this.longitude,
    this.rate,
    this.star,
    this.pin,
    this.mileRange,
    this.imgUrl,
  }):super();

  factory Agent.fromJson(Map<String, dynamic> json) => Agent(
    agentName: json["agent_name"],
    agentPhone: json["agent_phone"],
    agentEmail: json["agent_email"],
    address: json["address"],
    latitude: json["latitude"].toDouble(),
    longitude: json["longitude"].toDouble(),
    rate: json["rate"]==null? 0 : json["rate"].toDouble(),
    star: json["star"]==null?0 :json["star"].toDouble(),
    pin: json["pin"],
    mileRange: json["mile_range"].toDouble(),
    imgUrl: json["imgUrl"],
  );

  Map<String, dynamic> toJson() => {
    "agent_name": agentName,
    "agent_phone": agentPhone,
    "agent_email": agentEmail,
    "address": address,
    "latitude": latitude,
    "longitude": longitude,
    "rate": rate,
    "star": star,
    "pin": pin,
    "mile_range": mileRange,
    "imgUrl": imgUrl,
  };
}

