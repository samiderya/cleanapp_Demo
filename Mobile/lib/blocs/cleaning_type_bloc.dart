import 'package:cleaner_app/api/data.dart';
import 'package:http/http.dart' as http;
import 'package:cleaner_app/models/cleaning_type.dart';
import 'package:rxdart/rxdart.dart';
import 'dart:convert' as convert;

class CleaningTypeBloc{

  final _cleaningTypes=BehaviorSubject<List<CleaningType>>();

  //get
  Stream<List<CleaningType>> get cleaningTypes => _cleaningTypes.stream;
  //set
  Function(List<CleaningType>) get changeCleaningTypes=>_cleaningTypes.sink.add;

  dispose(){
    _cleaningTypes.close();
  }

  void loadCleaningTypes() async{

    var url="$IP_ADDRESS/api/cleaning/getAll";
    var response=await http.get(url);
    var json=convert.jsonDecode(response.body);
    var cleaningTypes=List<CleaningType>();
    try{
      Iterable list = json["model"];
      cleaningTypes = list.map((model) => CleaningType.fromJson(model)).toList();
    }catch(error){
      print(error);
    }
    //sort
     changeCleaningTypes(cleaningTypes);
  }

}