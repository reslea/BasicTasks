let currentBasket = [];

const basketUrl = 'https://localhost:5001/api/basket';

let basketPromice;

const basketIdStr = localStorage.getItem('basketId');
let basketId;
if(basketIdStr) {
  basketId = parseInt(basketIdStr);
  basketPromice = fetch(`${basketUrl}/${basketId}`)
  .then(response => response.json());

  basketPromice
  .then(basket => {
    basket.basketItems.forEach((bi =>  currentBasket.push(bi.product)));
    rerenderBasket();
  });
}

document.querySelector('#buy-btn').addEventListener('click', function() {
  fetch(`${basketUrl}/${basketId}/close`, { method: 'POST' })
    .then(() => {
      localStorage.clear();
      currentBasket = [];
      rerenderBasket();
    });
});

export function addToBasket(basketItem) {
  if (!basketPromice) {
    basketPromice = fetch(basketUrl, {
      method: 'POST'
    })
      .then(response => response.json())
  }

  basketPromice.then(basket => {
    console.log(basket);
    localStorage.setItem('basketId', basket.id);

    addBasketItem(basketItem, basket.id)
      .then(() => {
        const foundItem = currentBasket.filter(p => p.id === basketItem.id)[0];

        if (foundItem) {
          foundItem.count++;
        } else {
          currentBasket.push(basketItem);
        }
        rerenderBasket();
      });
  });
}

function addBasketItem(basketItem, basketId) {
  const basketItemUrl = 'https://localhost:5001/api/basket/item';
  return fetch(basketItemUrl, { 
    method: 'POST',
    body: JSON.stringify({ productId: basketItem.id, count: 1, basketId }),
    headers: {
      'Content-Type': 'application/json'
    }
  })
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

function createBasketArticle(basketItem) {      
  const article = document.createElement("article");
    article.classList.add("product");

    article.innerHTML = `
    <div class="product-image">
      <img src="${basketItem.image}" alt="">
    </div>
    <div class="product-title">${basketItem.title}</div>
    <div class="product-price">${basketItem.price} грн.</div>
    <div class="product-count">
      <input type="number" min="0" value="${basketItem.count}">
    </div>
    <div class="product-delete">
      <button>X</button>
    </div>`;

    return article;
}
