import 'dart:async';
import 'dart:convert';
import 'package:http/http.dart' as http;

class UserModel {
  String name;

  UserModel({required this.name});

  factory UserModel.fromJson(Map<String, dynamic> user) {
    return UserModel(name: user['name']);
  }

  static Future<UserModel> GetData(String username) async {
    var dataJson = await http
        .get(Uri.parse("http://api.test/api/v1/user?username=${username}"));
    var data = json.decode(dataJson.body);
    return UserModel.fromJson(data);
  }
}
