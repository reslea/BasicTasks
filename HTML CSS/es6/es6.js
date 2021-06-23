export class Product {
  constructor(name, price) {
    this._name = name;
    this._price = price;
    Product.productCount++;
  }

  get name() {
    console.log(`getter called`);
    return this._name;
  }

  set name(val) {
    console.log(`setter called`);
    this._name = val;
  }

  showInfo() {
    console.log(`${this.name} стоит ${this.price}`);
  }
}

function classesSample() {
  function ProductOld(name, price) {
    this.name = name;
    this.price = price;

    this.showInfo = () => {
      console.log(`${this.name} стоит ${this.price}`);
    };
  }

  class Product {
    constructor(name, price) {
      this._name = name;
      this._price = price;
      Product.productCount++;
    }

    get name() {
      console.log(`getter called`);
      return this._name;
    }

    set name(val) {
      console.log(`setter called`);
      this._name = val;
    }

    showInfo() {
      console.log(`${this.name} стоит ${this.price}`);
    }
  }
}

const counterResult = (function counter() {
  let currentNumber = 0;

  function some() {
    console.log(currentNumber);
  }

  return {
    increment: function() { currentNumber++ },
    dicrement: function() { currentNumber-- },
    showNumber: function() { some() },
  }
})();

function objectSamle() {
  const person = {
    nameOfPerson: 'Serg',
  };

  console.log(person.name); // undefined
  person.name = 'Serg';

  console.log(person['name of person']);
  person['name of person'] = 'Sergey';
  console.log(person['name of person']);
}

function thisExplain() {
  const product = {
    price: 100,
    discountPercents: [20, 10],
    getPrice: function() {
      const discouts = this.discountPercents
        .map((val) => this.price * val / 100);

      let price = this.price;
      for(const discount of discouts) {
        price -= discount;
      }

      return price;
    },

    showThis: function() {
      console.log(this);
    }
  }

  product.showThis();

  const anotherObject = {
    description: 'Чашка'
  };

  anotherObject.showThis = product.showThis;

  anotherObject.showThis();

}