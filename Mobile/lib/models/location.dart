import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';


class Location {
  final int id;
  final String name;
  final String address;
  final String city;
  final String state;
  final LatLng latLng;
  final String placesId;
  final bool isActive;

  Location({
    this.id,
    @required this.name,
    @required this.address,
    @required this.city,
    @required this.state,
    this.latLng,
    this.placesId,
    this.isActive,
  });
}