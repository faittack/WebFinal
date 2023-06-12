var productImageIndex = 1; // Initial image index
var imageCount = 4; // Total number of product images
var prevButton = document.getElementById('prev-button');
var nextButton = document.getElementById('next-button');
var productCount = 0;
var productCountElement = document.getElementById('product-count');

function changeProductImage(n) {
  productImageIndex += n; // Update the image index

  var productImage = document.getElementById('product-img');

  // Wrap around to the first image if the index exceeds the image count
  if (productImageIndex > imageCount) {
    productImageIndex = 1;
  }

  // Wrap around to the last image if the index goes below 1
  if (productImageIndex < 1) {
    productImageIndex = imageCount;
  }

  // Update the image source
  productImage.src = 'images/img' + productImageIndex + '.jpeg';

  // Disable previous button if on the first image
  prevButton.disabled = productImageIndex === 1;
  prevButton.classList.toggle('disabled', productImageIndex === 1);

  // Disable next button if on the last image
  nextButton.disabled = productImageIndex === imageCount;
  nextButton.classList.toggle('disabled', productImageIndex === imageCount);
}

function increaseCount() {
  productCount++;
  updateProductCount();
}

function decreaseCount() {
  if (productCount > 0) {
    productCount--;
    updateProductCount();
  }
}

function updateProductCount() {
  productCountElement.textContent = productCount;
}



