import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';

class register extends StatefulWidget {
  const register({super.key});

  @override
  State<register> createState() => _registerState();
}

class _registerState extends State<register> {
  final nama = TextEditingController();
  final username = TextEditingController();
  final alamat = TextEditingController();
  final password = TextEditingController();
  final konfirmasi_password = TextEditingController();
  bool _passwordVisible = true;
  bool _konfirmasi_passwordVisible = true;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: EdgeInsets.only(top: 50, right: 20, left: 20),
        color: Colors.white,
        child: Column(
          children: [
            Center(
              child: Form(
                  child: Column(
                children: [
                  const Text(
                    "Silahkan isi data pribadi anda",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                  ),
                  Container(
                    height: 10,
                  ),
                  TextFormField(
                    controller: nama,
                    decoration: InputDecoration(hintText: "Nama Lengkap"),
                  ),
                  Container(
                    height: 10,
                  ),
                  TextFormField(
                    controller: username,
                    decoration: InputDecoration(hintText: "Username"),
                  ),
                  Container(
                    height: 10,
                  ),
                  TextFormField(
                    controller: alamat,
                    decoration: InputDecoration(hintText: "Alamat"),
                  ),
                  Container(
                    height: 10,
                  ),
                  TextFormField(
                    obscureText: _passwordVisible,
                    controller: password,
                    decoration: InputDecoration(
                        hintText: "Password",
                        suffixIcon: IconButton(
                          icon: Icon(_passwordVisible
                              ? Icons.visibility
                              : Icons.visibility_off),
                          onPressed: () {
                            setState(() {
                              _passwordVisible = !_passwordVisible;
                            });
                          },
                        )),
                  ),
                  Container(
                    height: 10,
                  ),
                  TextFormField(
                    obscureText: _konfirmasi_passwordVisible,
                    controller: konfirmasi_password,
                    decoration: InputDecoration(
                        hintText: "Konfirmasi Password",
                        suffixIcon: IconButton(
                          icon: Icon(_konfirmasi_passwordVisible
                              ? Icons.visibility
                              : Icons.visibility_off),
                          onPressed: () {
                            setState(() {
                              _konfirmasi_passwordVisible =
                                  !_konfirmasi_passwordVisible;
                            });
                          },
                        )),
                  ),
                  Container(
                    height: 20,
                  ),
                  SizedBox(
                    width: double.infinity,
                    child: ElevatedButton(
                        onPressed: () async {
                          if (nama.text == "" ||
                              username.text == "" ||
                              alamat.text == "" ||
                              password.text == "" ||
                              konfirmasi_password == "") {
                            return showDialog(
                                context: context,
                                builder: (BuildContext context) {
                                  return const AlertDialog(
                                    content: Text(
                                        "Maaf, Semua kolom harus diisi sebelum melakukan pendaftaran!"),
                                  );
                                });
                          } else if (konfirmasi_password.text !=
                              password.text) {
                            return showDialog(
                                context: context,
                                builder: (BuildContext context) {
                                  return const AlertDialog(
                                    content: Text(
                                        "Maaf, Konfirmasi password yang anda masukan tidak sesuai dengan password yang anda buat!"),
                                  );
                                });
                          } else if (((json.decode((await http.post(Uri.parse(
                                  "http://api.test/api/v1/signup?name=${nama.text}&username=${username.text}&password=${password.text}")))
                              .body)) as Map<String, dynamic>)['created']) {
                            showDialog(
                                context: context,
                                builder: (BuildContext context) {
                                  return const AlertDialog(
                                    content: Text("User berhasil didaftarkan!"),
                                  );
                                });
                            Navigator.pop(context);
                          } else {
                            return showDialog(
                                context: context,
                                builder: (BuildContext context) {
                                  return const AlertDialog(
                                    content:
                                        Text("Maaf, user gagal didaftarkan!"),
                                  );
                                });
                          }
                        },
                        child: Text("Daftar")),
                  ),
                  Container(
                    height: 10,
                  ),
                  SizedBox(
                    width: double.infinity,
                    child: ElevatedButton(
                        onPressed: () {
                          Navigator.pop(context);
                        },
                        child: Text("Sudah Punya Akun")),
                  )
                ],
              )),
            )
          ],
        ),
      ),
    );
  }
}
