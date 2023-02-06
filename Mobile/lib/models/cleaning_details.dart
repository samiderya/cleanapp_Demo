import 'dart:convert';

import 'package:cleaner_app/models/agent.dart';
import 'package:cleaner_app/models/agent_star_rate.dart';
import 'package:cleaner_app/models/cleaning_type.dart';

import 'package:cleaner_app/models/transaction.dart';

import 'enums/package_type.dart';

String cleaningDetailsToJson(CleaningDetails data) => json.encode(data.toJson());
class CleaningDetails {
  final int id;
  CleaningType cleaningType;
  double totalHour;
  final PackageType packageType;
  int totalEmployee;
  final Agent agent;
  final AgentStarRate agentStarRate;
  final Transaction transaction;
  final DateTime dueDate;

  CleaningDetails({
    this.id,
    this.cleaningType,
    this.transaction,
    this.agent,
    this.agentStarRate,
    this.packageType,
    this.dueDate,
    this.totalEmployee,
    this.totalHour,
});

  factory CleaningDetails.fromJson(Map<String, dynamic> json) => CleaningDetails(
    cleaningType: json["cleaning_typeid"],
    totalHour: json["total_hour"],
    packageType: json["package_typeid"],
    totalEmployee: json["total_employee"],
    agent: json["agentid"],
    dueDate: DateTime.parse(json["due_date"]),
  );

  Map<String, dynamic> toJson() => {
    "cleaning_typeid": cleaningType.id,
    "total_hour": totalHour,
    "package_typeid": packageType,
    "total_employee": totalEmployee,
    "agentid": agent.id,
    "due_date": dueDate.toIso8601String(),
  };
}