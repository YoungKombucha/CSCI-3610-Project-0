# CSCI-3610-Project-0
The purpose of this project was to assess my understanding of secure coding to the best of my ability by creating a secure login form. The form collects a username and password from the user using textboxes, with the password hidden as it’s typed.

When the "Login" button is clicked, the application retrieves the entered credentials and checks them against hardcoded valid credentials.

The password entered by the user is transformed (hashed) using the SHA-256 algorithm before comparison, so the actual password is never stored in plain text or checked directly.

If the login is successful, a message confirms access; if not, the form counts failed attempts and eventually blocks further tries after a certain number.

Password Hashing: Instead of saving or comparing plain text passwords, the form uses SHA-256 hashing. This means even someone reading the code or gaining access to memory wouldn’t see the real password in use—only its hash (which cannot feasibly be reversed to find the original password).

Brute Force Protection: By limiting the number of login attempts you can make before being locked out, the form helps protect against brute-force attacks where an attacker tries many combinations to guess the password.

Masked Input: The password textbox hides the input, preventing over-the-shoulder observation.

Minimal Attack Surface: No sensitive data is exposed, and there’s no remote or database connection, making it safe for local demonstration.
