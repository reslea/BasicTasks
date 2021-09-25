// import { productItems } from "./productItems.js";
// import { addToBasket } from "./basket.js";

const store = document.querySelector('.store .row');
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
  productArticle.classList.add('card');
  productArticle.classList.add('col-md-4');
  productArticle.classList.add('col-lg-3');
  productArticle.classList.add('col-xl-2');

  productArticle.attributes

  productArticle.innerHTML = `
    <div class="card-img-top">
      <img src="${productItem.image}">
    </div>
    <div class="card-body">
      <h5 class="card-title">${productItem.title}</h5>
      <p class="card-text">${productItem.price} грн.</p>
      <button class="btn btn-primary">Add</button>
    </div>`;

    // const addButton = productArticle.querySelector('.store-item__add button');
    // addButton.addEventListener('click', function() {
    //   addToBasket(productItem);
    // });

    store.appendChild(productArticle);
}