// import { productItems } from "./productItems.js";
// import { addToBasket } from "./basket.js";

const store = document.querySelector('.store');
const spinner = document.querySelector('.products .spinner');

const productsUrl = 'https://localhost:5001/api/products';

const basketUrl = 'https://localhost:5001/api/basket';

const basketIdStr = localStorage.getItem('basketId');
if(basketIdStr) {
  const basketId = parseInt(basketIdStr);
  fetch(`${basketUrl}/${basketId}/count`)
    .then(response => response.json())
    .then(obj => {
      const basketItemsCountEl = document.querySelector('.basket-info span');
      basketItemsCountEl.textContent = obj.basketItemsCount;
    });
}

spinner.classList.remove('hidden');
fetch(productsUrl)
  .then(response => response.json())
  .then(productItems => {
    for(const productItem of productItems) {
      createStoreItem(productItem);
    }
  })
  .catch(() => console.log('failed to get products'))
  .finally(() => spinner.classList.add('hidden'));

function createStoreItem(productItem) {
  const productArticle = document.createElement('article');
  productArticle.classList.add('store-item');
  productArticle.attributes

  productArticle.innerHTML = `
    <div class="store-item__img">
      <img src="${productItem.image}">
    </div>
    <div class="store-item__title">${productItem.title}</div>
    <div class="store-item__price">${productItem.price} грн.</div>
    <div class="store-item__add">
      <button>Add</button>
    </div>`;

    // const addButton = productArticle.querySelector('.store-item__add button');
    // addButton.addEventListener('click', function() {
    //   addToBasket(productItem);
    // });

    store.appendChild(productArticle);
}