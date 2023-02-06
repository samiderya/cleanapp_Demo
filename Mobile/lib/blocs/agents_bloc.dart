import 'package:cleaner_app/api/data.dart';
import 'package:cleaner_app/models/agent.dart';
import 'package:geolocator/geolocator.dart';
import 'package:rxdart/rxdart.dart';
import 'package:http/http.dart' as http;
import 'dart:convert' as convert;

class AgentsBloc{

  final _agents=BehaviorSubject<List<Agent>>();

  //get
  Stream<List<Agent>> get agents => _agents.stream;
  //set
  Function(List<Agent>) get changeAgents=>_agents.sink.add;

  dispose(){
    _agents.close();
  }


  Future<Stream<List<Agent>>> loadAgents() async{
    Position position=await Geolocator.getCurrentPosition(desiredAccuracy: LocationAccuracy.high);

    var url="$IP_ADDRESS/api/agent/GetAgentsNearest/${position.latitude.toString()}/${position.longitude.toString()}";
    print("url:$url");
    var response=await http.get(url);
    var json=convert.jsonDecode(response.body);

    var agentList=List<Agent>();
    try{
      Iterable list = json["model"];
      agentList = list.map((model) => Agent.fromJson(model)).toList();
      print("agents:${agentList.length}");
     }catch(error){
      print("hata:$error");
    }

    //sort
    changeAgents(agentList);
    return _agents;
  }

}