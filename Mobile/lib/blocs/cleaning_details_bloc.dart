import 'dart:io';

import 'package:cleaner_app/api/data.dart';
import 'package:cleaner_app/models/agent.dart';
import 'package:cleaner_app/models/cleaning_details.dart';
import 'package:cleaner_app/models/cleaning_type.dart';
import 'package:http/http.dart' as http;
import 'package:rxdart/rxdart.dart';
import 'dart:convert' as convert;

class CleaningDetailsBloc{

  final _cleaningDetails=BehaviorSubject<CleaningDetails>();

  //get
  Stream<CleaningDetails> get cleaningDetails => _cleaningDetails.stream;
  //set
  Function(CleaningDetails) get changeCleaningDetails=>_cleaningDetails.sink.add;

  dispose(){
    _cleaningDetails.close();
  }

  CleaningType getCleaningType(){
    return _cleaningDetails.value?.cleaningType;
  }
  void setTotalEmployee(int totalEmployee) async {
    CleaningDetails cleaningDetails=_cleaningDetails.value;
    cleaningDetails.totalEmployee=totalEmployee;
  _cleaningDetails.sink.add(cleaningDetails);
  print("tttttttt:${_cleaningDetails.value.totalEmployee}");

  changeCleaningDetails(cleaningDetails);
}

  void setTotalHours(double totalHours) async {
    CleaningDetails cleaningDetails=_cleaningDetails.value;
    cleaningDetails.totalHour=totalHours;
    _cleaningDetails.sink.add(cleaningDetails);
    print("hhhhhhhh:${_cleaningDetails.value.totalHour}");
    changeCleaningDetails(cleaningDetails);
  }
  void setCleaningType(CleaningType cleaningType) async{
    CleaningDetails cleaningDetails=CleaningDetails(cleaningType: cleaningType,);
    _cleaningDetails.sink.add(cleaningDetails);
    print("yyyyyyy:${_cleaningDetails.value.cleaningType.cleaningType}");
    changeCleaningDetails(cleaningDetails);
  }

  void setAgent(Agent agent) async{
    print("zzzzz:${_cleaningDetails.value?.cleaningType?.cleaningType}");
     CleaningDetails cleaningDetails=CleaningDetails(agent: agent,cleaningType: _cleaningDetails.value?.cleaningType);
    _cleaningDetails.sink.add(cleaningDetails);
    changeCleaningDetails(cleaningDetails);
  }
  Agent getAgent(){
    return _cleaningDetails.value?.agent;
  }
  void saveCleaningDetails(CleaningDetails cleaningDetails) async{

    var url="$IP_ADDRESS/api/cleaning/CleaningDetailSave";
    String body=cleaningDetailsToJson(cleaningDetails);
    var json;
    try {
      await http.post(url, body: body,
          headers: {HttpHeaders.acceptHeader: "application/json",
            HttpHeaders.contentTypeHeader: "application/json-patch+json"})
          .then((response) {
        json = convert.jsonDecode(response.body);
      });
    } catch (ex){
      print(ex);
    }
      var details = CleaningDetails.fromJson(json["model"]);
      //sort
      changeCleaningDetails(details);

  }

}