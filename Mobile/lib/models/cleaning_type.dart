
class CleaningType {
  CleaningType({
    this.id,
    this.cleaningNo,
    this.cleaningType,
    this.imgPath,
    this.description,
    this.createdBy,
    this.createdAt,
    this.isActive,
  });

  int id;
  String cleaningNo;
  String cleaningType;
  String imgPath;
  String description;
  int createdBy;
  DateTime createdAt;
  int isActive;

  factory CleaningType.fromJson(Map<String, dynamic> json) =>
      CleaningType(
        id: json["id"],
        cleaningNo: json["cleaning_no"],
        cleaningType: json["cleaning_type"],
        imgPath: json["imgName"],
        description: json["description"] == null ? null : json["description"],
        createdBy: json["created_by"],
        createdAt: DateTime.parse(json["created_at"]),
        isActive: json["is_active"],
      );

  Map<String, dynamic> toJson() =>
      {
        "id": id,
        "cleaning_no": cleaningNo,
        "cleaning_type": cleaningType,
        "img_path": imgPath,
        "description": description == null ? null : description,
        "created_by": createdBy,
        "created_at": createdAt.toIso8601String(),
        "is_active": isActive,
      };

}