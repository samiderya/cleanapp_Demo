enum UserType {

  agent,
  customer,
  admin

}
userTypeFromInt(int value) {
  switch (value) {
    case 1:
      return UserType.admin;
    case 2:
      return UserType.customer;
    case 3:
      return UserType.agent;
    default:
      return UserType.customer;
  }
}
extension UserTypeExtension on UserType {
  int get value {
    switch (this) {
      case UserType.admin:
        return 1;
      case UserType.customer:
        return 2;
      case UserType.agent:
        return 3;
      default:
        return 0;
    }
  }
  }






