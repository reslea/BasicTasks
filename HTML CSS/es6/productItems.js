class Product {
  static idCounter = 1;
  constructor(title, price, image) {
    this.id = Product.idCounter++;
    this.title = title;
    this.price = price;
    this.image = image;
    this.count = 1;
  }
}

export const productItems = [
  new Product(
    "Чашка", 
    249.0,
    "https://gifty.in.ua/public/cache/images/2/0/0/5/6/e45c88cab5fe5b7cb1e5819c65f86a15_900_700.jpg",
  ),new Product(
    "Футболка",
    100,
    "https://img.loveandlive.ua/r/wU4a_LUWON4/fit/640/640/ce/1/plain/images/products/1/5689/356972089/MNK__ZZ3-04314M.00P-20_.jpg",
  )];