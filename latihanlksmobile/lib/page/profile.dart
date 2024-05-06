import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:latihanlksmobile/model/user_model.dart';
import 'package:latihanlksmobile/global.dart' as global;

class profile extends StatefulWidget {
  const profile({super.key});

  @override
  State<profile> createState() => _profileState();
}

class _profileState extends State<profile> {
  UserModel user = new UserModel(name: "");

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Center(
          child: Text("Profile"),
        ),
      ),
      backgroundColor: const Color.fromARGB(255, 231, 231, 231),
      body: Container(
        child: Column(
          children: [
            Container(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  Image(
                    image: AssetImage('assets/images/profile.jpg'),
                    width: 100,
                    height: 100,
                  ),
                  Container(
                    padding: EdgeInsets.all(10),
                    child: FutureBuilder(
                      builder: (context, snapshoot) {
                        if (snapshoot.connectionState == ConnectionState.done) {
                          if (snapshoot.hasError) {
                            return Center(
                              child: Text(
                                "${snapshoot.error}",
                                style: TextStyle(fontWeight: FontWeight.bold),
                              ),
                            );
                          } else if (snapshoot.hasData) {
                            return Center(
                                child: Text("${user.name}\n0812345\nBandung",
                                    style: TextStyle(
                                        fontWeight: FontWeight.bold)));
                          }
                        }
                        return Center(
                          child: CircularProgressIndicator(),
                        );
                      },
                      future: UserModel.GetData(global.data)
                          .then((value) => user = value),
                    ),
                  )
                ],
              ),
            ),
            Container(
              color: Colors.white,
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  TextButton(
                      onPressed: () {
                        Navigator.pushReplacementNamed(context, "/");
                      },
                      child: Row(
                        children: [
                          Icon(Icons.logout),
                          Container(
                            width: 10,
                          ),
                          Text("Keluar")
                        ],
                      ))
                ],
              ),
            ),
          ],
        ),
      ),
      bottomNavigationBar: BottomNavigationBar(
        items: [
          BottomNavigationBarItem(
              icon: IconButton(
                icon: Icon(Icons.shopping_cart_sharp),
                onPressed: () {
                  Navigator.pushReplacementNamed(context, "/menu");
                },
              ),
              label: "Manu"),
          BottomNavigationBarItem(icon: Icon(Icons.person), label: "Profile")
        ],
        currentIndex: 1,
      ),
    );
  }
}
