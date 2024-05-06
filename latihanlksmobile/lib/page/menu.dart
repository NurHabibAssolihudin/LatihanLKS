import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

void getProducts() {

}

class menu extends StatefulWidget {
  const menu({super.key});

  @override
  State<menu> createState() => _menuState();
}

class _menuState extends State<menu> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Menu Food XYZ"),
      ),
      backgroundColor: const Color.fromARGB(255, 231, 231, 231),
      body: Container(
        child: Column(
          children: [
            Container(
              padding: EdgeInsets.all(10),
              child: Form(
                  child: TextFormField(
                decoration: InputDecoration(
                    hintText: "Cari Item",
                    suffixIcon: Icon(Icons.search_rounded)),
              )),
            ),
            Column(
              children: [
                Text("Semua"),
                Container(
                    width: double.infinity,
                    height: 400,
                    child: FutureBuilder(future: getProducts(), builder: (context, snapshoot){

                    })
                     ListView.builder(
                        itemCount: 5,
                        itemBuilder: (BuildContext context, int index) {
                          return Container(
                            height: 50,
                            color: Colors.amber,
                            child: Text("halo"),
                          );
                        }))
              ],
            )
          ],
        ),
      ),
      bottomSheet: ButtonBayar(),
      bottomNavigationBar: BottomNavigationBar(
        items: [
          BottomNavigationBarItem(
              icon: IconButton(
                icon: Icon(Icons.shopping_cart_sharp),
                onPressed: () {},
              ),
              label: "Manu"),
          BottomNavigationBarItem(
              icon: IconButton(
                icon: Icon(Icons.person),
                onPressed: () {
                  Navigator.pushReplacementNamed(context, "/profile");
                },
              ),
              label: "Profile")
        ],
      ),
    );
  }
}

class ButtonBayar extends StatefulWidget {
  const ButtonBayar({super.key});

  @override
  State<ButtonBayar> createState() => _ButtonBayarState();
}

class _ButtonBayarState extends State<ButtonBayar> {
  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      height: 55,
      padding: EdgeInsets.all(10),
      child: ElevatedButton(onPressed: () {}, child: Text("Bayar Sekarang")),
    );
  }
}
