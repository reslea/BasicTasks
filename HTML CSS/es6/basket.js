const currentBasket = [];

export function addToBasket(productItem) {
  const foundItem = currentBasket.filter(p => p.id === productItem.id)[0];

  if (foundItem) {
    foundItem.count++;
  } else {
    currentBasket.push(productItem);
  }
  rerenderBasket();
}

const productsSection = document.querySelector('.products');

function rerenderBasket() {
  // очистить внутренности корзины
  productsSection.innerHTML = '';

  // заполнить корзину заново
  for(const item of currentBasket) {
    const basketArticle = createBasketArticle(item);
    
    productsSection.appendChild(basketArticle);
  }
}

function createBasketArticle(productItem) {      
  const article = document.createElement("article");
    article.classList.add("product");

    article.innerHTML = `
    <div class="product-image">
      <img src="${productItem.image}" alt="">
    </div>
    <div class="product-title">${productItem.title}</div>
    <div class="product-price">${productItem.price} грн.</div>
    <div class="product-count">
      <input type="number" min="0" value="${productItem.count}">
    </div>
    <div class="product-delete">
      <button>X</button>
    </div>`;

    return article;
}
