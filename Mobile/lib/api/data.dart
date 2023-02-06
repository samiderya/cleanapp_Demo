const String IP_ADDRESS= "http://198.12.227.32:5050";

class AgentServiceType{
  AgentServiceType({
    this.title = '',
    this.isSelected = false,
  });

  String title;
  bool isSelected;

  static List<AgentServiceType> serviceTypes = <AgentServiceType>[
  AgentServiceType(
  title: 'One Time',
  isSelected: false,
  ),
  AgentServiceType(
  title: 'Package',
  isSelected: true,
  ),
  ];
}

class AgentService {
  AgentService({
    this.title = '',
    this.isSelected = false,
  });

  String title;
  bool isSelected;

}