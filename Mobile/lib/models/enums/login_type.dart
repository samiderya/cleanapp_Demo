enum LoginType {
  email,
  google,
  twitter,
  facebook,
}
loginTypeFromInt(int value) {
  switch (value) {
    case 1:
      return LoginType.email;
    case 2:
      return LoginType.facebook;
    case 3:
      return LoginType.twitter;
    default:
      return LoginType.google;
  }
}

extension LoginTypeExtension on LoginType {

  int get value {
    switch (this) {
      case LoginType.email:
        return 1;
      case LoginType.facebook:
        return 2;
      case LoginType.twitter:
        return 3;
      case LoginType.google:
        return 4;
      default:
        return 0;
    }
  }
}