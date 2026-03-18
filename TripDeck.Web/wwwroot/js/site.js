$(document).ready(function () {
  fetchDestinations()
    .then((destinations) => {
      initializeHeroCarousel(destinations);
      initializeFeaturedGrid(destinations);
    })
    .catch((error) => {
      console.error("Error fetching destinations:", error);
      $("#loading").html(
        "<p>Error loading destinations. Please refresh the page.</p>"
      );
    });
});

// Simulate API call to fetch active destinations with a delay
function fetchDestinations() {
  return new Promise((resolve, reject) => {
    $.ajax({
      url: "/Home/GetActiveDestinations",
      method: "GET",
      dataType: "json",
      success: function (data) {
        setTimeout(() => {
          const activeDestinations = data
            .filter((dest) => dest.isActive)
            .sort((a, b) => a.displayOrder - b.displayOrder);
          resolve(activeDestinations);
        }, 1500);
      },
      error: function (_xhr, _status, error) {
        reject(error);
      },
    });
  });
}

// Initialize the hero carousel with active destinations marked as hero
function initializeHeroCarousel(destinations) {
  const heroCarousel = $("#heroCarousel");
  const heroDestinations = destinations.filter((dest) => dest.isHero);

  heroCarousel.empty();

  heroDestinations.forEach((destination) => {
    heroCarousel.append(createHeroSlide(destination));
  });

  heroCarousel.owlCarousel({
    items: 1,
    loop: true,
    nav: true,
    dots: true,
    autoplay: true,
    autoplayTimeout: 5000,
    autoplayHoverPause: true,
    animateOut: "fadeOut",
    animateIn: "fadeIn",
    navText: [
      '<i class="fas fa-chevron-left"></i>',
      '<i class="fas fa-chevron-right"></i>',
    ],
    onInitialized: function () {
      $("#loading").fadeOut();
      heroCarousel.fadeIn();
    },
  });
}

// Initialize the featured grid with active destinations that are not marked as hero
function initializeFeaturedGrid(destinations) {
  const featuredGrid = $("#featuredGrid");
  featuredGrid.empty();

  destinations.forEach((destination) => {
    featuredGrid.append(createFeaturedCard(destination));
  });
}

function createHeroSlide(destination) {
  return `
          <div class="hero-slide">
              <div class="hero-background" style="background-image: url('${destination.imageName}')"></div>
              <div class="hero-overlay"></div>
              <div class="hero-content">
                  <div class="hero-location">
                      <i class="fas fa-map-marker-alt"></i>
                      ${destination.location}
                  </div>
                  <h1 class="hero-title">${destination.name}</h1>
                  <p class="hero-description">${destination.description}</p>
                  <div class="hero-actions">
                      <a href="${destination.linkUrl}" target="_blank" class="btn-primary">
                          Explore Now <i class="fas fa-arrow-right"></i>
                      </a>
                  </div>
              </div>
          </div>
      `;
}

function createFeaturedCard(destination) {
  return `
          <div class="destination-card">
              <div class="card-image" style="background-image: url('${destination.imageName}')"></div>
              <div class="card-content">
                  <h3 class="card-title">${destination.name}</h3>
                  <p class="card-description">${destination.description}...</p>
                  <a href="${destination.linkUrl}" target="_blank" class="card-link">
                      Learn More <i class="fas fa-arrow-right"></i>
                  </a>
              </div>
          </div>
      `;
}

$('a[href^="#"]').on("click", function (event) {
  var target = $(this.getAttribute("href"));
  if (target.length) {
    event.preventDefault();
    $("html, body")
      .stop()
      .animate(
        {
          scrollTop: target.offset().top - 80,
        },
        1000
      );
  }
});

$(window).scroll(function () {
  if ($(window).scrollTop() > 100) {
    $(".navbar").addClass("scrolled");
  } else {
    $(".navbar").removeClass("scrolled");
  }
});

$(document).on("error", "img", function () {
  $(this).attr(
    "src",
    "https://images.unsplash.com/photo-1488646953014-85cb44e25828?w=1200&h=800&fit=crop"
  );
});
