document.addEventListener('DOMContentLoaded', function () {
    const homeLink = document.getElementById('home-link');
    homeLink.addEventListener('click', function (event) {
        event.preventDefault();
        // Handle returning to home page or main view
        alert('Implement navigation logic here');
    });

    const carData = [
        {
            name: 'Toyota Camry',
            manufacturer: 'Toyota Motor Corporation, Japan',
            power: 'Available engines from 2.5L (206 hp) to 3.5L (301 hp)',
            price: 'Approximately $25,000 to $35,000 USD',
            features: 'Comfortable sedan with high reliability and modern safety systems. Known for its fuel efficiency and spacious interior.',
            image: 'toyota_camry.jpg' // Assuming you have the image file
        },
        {
            name: 'Porsche 911',
            manufacturer: 'Porsche AG, Germany',
            power: 'From 379 hp in base model to 690 hp in Turbo S model',
            price: 'Approximately $100,000 to $200,000 USD',
            features: 'Legendary sports car with rear-engine layout, exquisite design, and high dynamic performance. Offers advanced technology and customization options.',
            image: 'porsche_911.jpg'
        },
        {
            name: 'Tesla Model 3',
            manufacturer: 'Tesla, Inc., USA',
            power: 'One electric motor version offering up to 450 hp',
            price: 'Approximately $40,000 to $60,000 USD depending on configuration',
            features: 'Electric car with high range, modern interior, and advanced autopilot systems. Known for its environmental efficiency and fast charging.',
            image: 'tesla_model_3.jpg'
        },
        {
            name: 'BMW X5',
            manufacturer: 'Bayerische Motoren Werke AG, Germany',
            power: 'From 335 hp in base version to 523 hp in M50i version',
            price: 'Approximately $60,000 to $90,000 USD',
            features: 'Premium crossover with powerful petrol or diesel engines, luxurious interior, and advanced driver assistance technologies.',
            image: 'bmw_x5.jpg'
        },
        {
            name: 'Honda Civic',
            manufacturer: 'Honda Motor Co., Ltd., Japan',
            power: 'From 158 hp to 306 hp in Civic Type R sports version',
            price: 'Approximately $20,000 to $35,000 USD',
            features: 'Compact sedan with high fuel efficiency, reliability, and excellent dynamic characteristics. Offers a wide range of configurations for various needs and preferences.',
            image: 'honda_civic.jpg'
        }
    ];

    const carListSection = document.getElementById('car-list');

    // Function to create a card for each car and append it to the car list section
    function renderCarList() {
        carData.forEach(car => {
            const card = document.createElement('div');
            card.classList.add('card');

            // Construct card HTML
            const html = `
                <h2>${car.name}</h2>
                <p><strong>Manufacturer:</strong> ${car.manufacturer}</p>
                <p><strong>Power:</strong> ${car.power}</p>
                <p><strong>Price:</strong> ${car.price}</p>
                <p><strong>Features:</strong> ${car.features}</p>
                <img src="images/${car.image}" alt="${car.name}">
            `;
            card.innerHTML = html;
            carListSection.appendChild(card);
        });
    }

    renderCarList();

    // Handle form submission to add a review
    const addReviewForm = document.getElementById('add-review-form');
    addReviewForm.addEventListener('submit', function (event) {
        event.preventDefault();

        const reviewerName = document.getElementById('reviewer-name').value;
        const reviewText = document.getElementById('review-text').value;

        // Store review in local storage or send to server
        // For simplicity, let's just log it for now
        console.log(`Review submitted by ${reviewerName}: ${reviewText}`);

        // Clear form fields
        addReviewForm.reset();
    });
});
