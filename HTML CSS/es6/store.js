import { productItems } from "./productItems.js";
import { addToBasket } from "./basket.js";

const store = document.querySelector('.store');
for(const productItem of productItems) {
  createStoreItem(productItem);
}

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

    const addButton = productArticle.querySelector('.store-item__add button');
    addButton.addEventListener('click', function() {
      addToBasket(productItem);
    });

    store.appendChild(productArticle);
}