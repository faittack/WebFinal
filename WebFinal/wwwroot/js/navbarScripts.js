document.addEventListener("DOMContentLoaded", function () {
    var userIcon = document.querySelector(".user-icon");
    var dropdown = document.querySelector(".dropdown");
  
    userIcon.addEventListener("click", function () {
      dropdown.classList.toggle("open");
  
      // Relocate dropdown if it overflows the screen
      if (dropdown.classList.contains("open")) {
        var dropdownRect = dropdown.getBoundingClientRect();
        if (dropdownRect.right > window.innerWidth) {
          dropdown.style.left = "auto";
          dropdown.style.right = "0";
        }
      }
    });
  
    document.addEventListener("click", function (event) {
      if (!dropdown.contains(event.target) && !userIcon.contains(event.target)) {
        dropdown.classList.remove("open");
      }
    });
  });
  