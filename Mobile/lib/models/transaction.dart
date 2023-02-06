import 'package:cleaner_app/models/enums/card_type.dart';
import 'package:cleaner_app/models/enums/transaction_type.dart';
import 'package:cleaner_app/models/user.dart';


import 'enums/transaction_status.dart';
//executivehand.com
class Transaction{
  final int id;
  final CardType cardType; //visa,master etc
  final String cardOwnerName;
  final String cardNumber;
  final String expiredDate;
  final double ccv;
  final double amount;
  final ApplicationUser user;
  final TransactionType transactionType;
  final TransactionStatus status;

  Transaction({
    this.id,
    this.cardType,
    this.cardOwnerName,
    this.cardNumber,
    this.expiredDate,
    this.ccv,
    this.amount,
    this.user,
    this.transactionType,
    this.status,
});
}