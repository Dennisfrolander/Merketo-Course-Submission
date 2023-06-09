﻿const toggleMenuButton = (attribute) => {
    try {
        const btn = document.querySelector(attribute)

        btn.addEventListener('click', function () {
            const element = document.querySelector(btn.getAttribute('data-target'))
            const contains = element.classList.contains('open-menu')

            element.classList.toggle('open-menu', !contains)
            btn.classList.toggle('btn-outline-dark', !contains)
            btn.classList.toggle('btn-toggle-white', !contains)
        })
    }
    catch { }
}


//RegEx
const regExFirstAndLastName = /^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$/;
const regExEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
const regExPostalCode = /^(?:SE-)?\d{3}\s?\d{2}$/;
const regExMobile = /^07[02369]\d{7}$/;
const regExCity = /^[a-zA-ZåäöÅÄÖ]{3,}$/;
const regExDescription = /^[A-Za-z0-9]{1,500}$/;
const regExOnlyNumbers = /^\d+$/;


const createAccountValidate = () => {

    try {
        const inputs = document.querySelectorAll('[data-val="true"]');
        for (let input of inputs) {
            input.addEventListener("keyup", function (e) {
                switch (e.target.id) {

                    case 'FirstName':
                        regexValidator(e.target, regExFirstAndLastName, "First Name is invalid", "");
                        break;
                    case 'LastName':
                        regexValidator(e.target, regExFirstAndLastName, "Last Name is invalid", "");
                        break;
                    case 'StreetName':
                        textValidator(e.target, 5, "Street name is invalid", "");
                        break;
                    case 'PostalCode':
                        regexValidator(e.target, regExPostalCode, "Postal code is invalid, (12345 / 123 45)", "");
                        break;
                    case 'City':
                        regexValidator(e.target, regExCity, "City is invalid", "");
                        break;
                    case 'PhoneNumber':
                        regexValidator(e.target, regExMobile, "Mobile number is invalid", "");
                        break;
                    case 'Email':
                        regexValidator(e.target, regExEmail, "Email is invalid", "");
                        break;
                    case 'Password':
                        passwordValidate("password-message");
                        break;
                    case 'ConfirmPassword':
                        comparePassword(e.target)
                        break;
                }
            })
        }

    }
    catch { }
}

const CreateContactValidate = () => {
    try {
        const inputs = document.querySelectorAll('[data-val="true"]');
        for (let input of inputs) {
            input.addEventListener("keyup", function (e) {
                switch (e.target.id) {
                    case 'FirstName':
                        regexValidator(e.target, regExFirstAndLastName, "First Name is invalid", "");
                        break;
                    case 'LastName':
                        regexValidator(e.target, regExFirstAndLastName, "Last Name is invalid", "");
                        break;
                    case 'Email':
                        regexValidator(e.target, regExEmail, "Email is invalid", "");
                        break;
                    case 'PhoneNumber':
                        regexValidator(e.target, regExMobile, "Mobile number is invalid", "");
                        break;
                    case 'Description':
                        descriptionChecker(500);
                        break;
                }
            })
        }
    }
    catch { }
}

const comparePassword = (target) => {
    const password = document.getElementById("Password");
    const comparePassword = document.getElementById(target.id);

    if (password.value != comparePassword.value) {
        document.querySelector('[data-valmsg-for="ConfirmPassword"]').innerHTML = "Passwords are not equal";
    }
    else
        document.querySelector('[data-valmsg-for="ConfirmPassword"]').innerHTML = "";
}

const createProductValidate = () => {
    try {
        const inputs = document.querySelectorAll('[data-val="true"]');
        for (let input of inputs) {
            input.addEventListener("keyup", function (e) {
                switch (e.target.id) {

                    case 'Description':
                        descriptionChecker(500);
                        break;
                    case 'Price':
                        regexValidator(e.target, regExOnlyNumbers, "Price can only contain numbers", "");
                        break;
                }
            })
        }

        const discount = document.getElementById("Discount");
        const discountError = document.getElementById('discount-error');
        const regEx = /^(?:100|\d{1,2})$/;

        discount.addEventListener("keyup", function () {
            if (!regEx.test(discount.value) || /\+|-/.test(discount.value)) {
                discountError.innerHTML = "It can only be between 0-100";
            } else {
                discountError.innerHTML = "";
            }
        });
    }
    catch { }
}

const loginValidate = () => {
    try {
        const inputs = document.querySelectorAll('[data-val="true"]');
        for (let input of inputs) {
            input.addEventListener("keyup", function (e) {
                switch (e.target.id) {
                    case 'Email':
                        regexValidator(e.target, regExEmail, "Email is invalid", "");
                        break;
                    case 'Password':
                        passwordValidate("password-message");
                        break;
                }
            })
        }
    }
    catch { }
}


/**
 * Validates a given input against a given regular expression.
 * @param {HTMLElement} target - The input element to validate.
 * @param {RegExp} regEx - The regular expression to validate against.
 * @param {string} errorMessage - The error message to display if the input is invalid.
 * @param {string} noErrorMessage - The message to display if the input is valid.
 */
const regexValidator = (target, regEx, errorMessage, noErrorMessage) => {

    if (!regEx.test(target.value) && target.value != "") {
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = errorMessage
    }
    else {
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = noErrorMessage;
    }
}


/**
 * Validates a given input against a given minimum length.
 * @param {HTMLElement} target - The input element to validate.
 * @param {number} minLength - The minimum length the input must be.
 * @param {string} errorMessage - The error message to display if the input is invalid.
 * @param {string} noErrorMessage - The message to display if the input is valid.
 */
const textValidator = (target, minLength, errorMessage, noErrorMessage) => {
    if (target.value.length < minLength) {
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = errorMessage
    }
    else {
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = noErrorMessage;
    }
}


const passwordValidate = (expression) => {
    const myInput = document.getElementById("Password");
    const letter = document.getElementById("letter");
    const capital = document.getElementById("capital");
    const number = document.getElementById("number");
    const special = document.getElementById("special");
    const length = document.getElementById("length");
    const everything = document.getElementById("everything");

    document.getElementById(expression).style.display = "block";

    myInput.onkeyup = function () {
        const lowerCaseLetters = /[a-z]/g;
        if (myInput.value.match(lowerCaseLetters)) {
            letter.classList.remove("invalid");
            letter.classList.add("valid");
        } else {
            letter.classList.remove("valid");
            letter.classList.add("invalid");
        }


        const upperCaseLetters = /[A-Z]/g;
        if (myInput.value.match(upperCaseLetters)) {
            capital.classList.remove("invalid");
            capital.classList.add("valid");
        } else {
            capital.classList.remove("valid");
            capital.classList.add("invalid");
        }


        const numbers = /[0-9]/g;
        if (myInput.value.match(numbers)) {
            number.classList.remove("invalid");
            number.classList.add("valid");
        } else {
            number.classList.remove("valid");
            number.classList.add("invalid");
        }


        const specialCharacters = /[@$!%*#?&]/g;
        if (myInput.value.match(specialCharacters)) {
            special.classList.remove("invalid");
            special.classList.add("valid");
        } else {
            special.classList.remove("valid");
            special.classList.add("invalid");
        }


        if (myInput.value.length >= 8) {
            length.classList.remove("invalid");
            length.classList.add("valid");
        } else {
            length.classList.remove("valid");
            length.classList.add("invalid");
        }


        const validPassword = myInput.value.match(lowerCaseLetters) &&
            myInput.value.match(upperCaseLetters) &&
            myInput.value.match(numbers) &&
            myInput.value.match(specialCharacters) &&
            myInput.value.length >= 8;
        if (validPassword) {
            everything.classList.remove("invalid");
            everything.classList.add("valid");
        } else {
            everything.classList.remove("valid");
            everything.classList.add("invalid");
        }
    }
}

const descriptionChecker = (maxCharacters) => {

    const descriptionInput = document.getElementById("Description");
    const descriptionMessage = document.getElementById("description-message")
    const _maxCharacters = maxCharacters;
    const writtenCharacters = _maxCharacters - descriptionInput.value.length;

    if (descriptionInput.value.length > 0 && descriptionInput.value.length <= _maxCharacters) {
        descriptionMessage.innerHTML = `Characters left ${writtenCharacters} `;
        descriptionMessage.classList.remove("text-danger");
    }
    else if (descriptionInput.value.length > _maxCharacters) {
        descriptionMessage.innerHTML = `It must be ${_maxCharacters} character or less (${descriptionInput.value.length})`;
        descriptionMessage.classList.add("text-danger");
    }
}



const carousel = () => {
    try {
        var slides = document.querySelectorAll('.slide');
        var prevBtn = document.querySelector('.prevBtn');
        var nextBtn = document.querySelector('.nextBtn');
        var currentSlide = 0;

        function showSlide(direction) {
            if (direction === 'next') {
                currentSlide = (currentSlide + 1) % slides.length;
            } else if (direction === 'prev') {
                currentSlide = (currentSlide - 1 + slides.length) % slides.length;
            }

            var slideWidth = slides[currentSlide].offsetWidth;
            var offset = -currentSlide * slideWidth;
            for (var i = 0; i < slides.length; i++) {
                slides[i].style.transform = 'translateX(' + offset + 'px)';
            }
        }

        prevBtn.addEventListener('click', function () {
            showSlide('prev');
        });

        nextBtn.addEventListener('click', function () {
            showSlide('next');
        });

        startAutoslide(showSlide, 'next', 10);
    }
    catch { }

};

const startAutoslide = (_function, _direction, _seconds) => {
    setInterval(function () {
        _function(_direction);
    }, _seconds * 1000);
};