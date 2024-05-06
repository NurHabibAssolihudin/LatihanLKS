import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:latihanlksmobile/global.dart' as global;

class login extends StatefulWidget {
  const login({super.key});

  @override
  State<login> createState() => _loginState();
}

class _loginState extends State<login> {
  final username = TextEditingController();
  final password = TextEditingController();
  bool _isObsecure = true;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Container(
            color: Colors.white,
            padding:
                const EdgeInsets.only(top: 30, right: 20, left: 20, bottom: 30),
            child: Column(
              children: [
                const Center(
                  child: Column(
                    children: [
                      Image(
                        image: AssetImage("assets/images/login.png"),
                        height: 90,
                      ),
                      Text(
                        "Login",
                        style: TextStyle(
                            fontSize: 24, fontWeight: FontWeight.bold),
                      )
                    ],
                  ),
                ),
                Center(
                  child: Column(
                    children: [
                      Form(
                          child: Column(
                        children: [
                          TextFormField(
                            controller: username,
                            decoration: const InputDecoration(
                              hintText: "Username",
                            ),
                          ),
                          Container(
                            height: 10,
                          ),
                          TextFormField(
                            controller: password,
                            obscureText: _isObsecure,
                            decoration: InputDecoration(
                                hintText: "Password",
                                suffixIcon: IconButton(
                                    onPressed: () {
                                      setState(() {
                                        _isObsecure = !_isObsecure;
                                      });
                                    },
                                    icon: Icon(_isObsecure
                                        ? Icons.visibility
                                        : Icons.visibility_off))),
                          ),
                          Container(
                            height: 20,
                          ),
                          SizedBox(
                            width: double.infinity,
                            child: ElevatedButton(
                                onPressed: () async {
                                  if (username.text == "" ||
                                      password.text == "") {
                                    return showDialog(
                                        context: context,
                                        builder: (BuildContext context) {
                                          return const AlertDialog(
                                            content: Text(
                                                "Maaf, Kolom username dan password tidak boleh kosong"),
                                          );
                                        });
                                  } else if (((json.decode(
                                      (await http.post(Uri.parse(
                                              "http://api.test/api/v1/auth?username=${username.text}&password=${password.text}")))
                                          .body)) as Map<String,
                                      dynamic>)['auth']) {
                                    global.data = ((json.decode(
                                        (await http.post(Uri.parse(
                                                "http://api.test/api/v1/auth?username=${username.text}&password=${password.text}")))
                                            .body)) as Map<String,
                                        dynamic>)['username'];
                                    Navigator.pushReplacementNamed(
                                        context, '/menu');
                                  } else {
                                    return showDialog(
                                        context: context,
                                        builder: (BuildContext context) {
                                          return const AlertDialog(
                                            content: Text(
                                                "Maaf, user dengan identitas tersebut tidak terdaftar!"),
                                          );
                                        });
                                  }
                                },
                                child: const Text("Login")),
                          ),
                          Container(
                            height: 10,
                          ),
                          SizedBox(
                            width: double.infinity,
                            child: ElevatedButton(
                                onPressed: () {
                                  Navigator.pushNamed(context, '/register');
                                },
                                child: const Text("Daftar")),
                          ),
                        ],
                      ))
                    ],
                  ),
                )
              ],
            )));
  }
}
