class ProductModel {
  int id;
  String name;
  String image;
  BigInt price;

  ProductModel({required this.id,required this.name,required this.image,required this.price});

  factory ProductModel.fromJson(Map<String, dynamic> product){
    return ProductModel(id: product['id'], name: product['name'], image: image, price: price)
  }
}
