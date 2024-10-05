import itertools
import string
import time

# The target password (you can modify this)
target_password = "abc123D"

# The character set to use (lowercase, uppercase, digits)
characters = string.ascii_lowercase + string.ascii_uppercase + string.digits

# Start measuring the time
start_time = time.time()

def brute_force_crack():
    # Start from length 1 and increase the length of the guessed password
    for length in range(1, 9):  # Adjust the range as needed for longer passwords
        # Generate all combinations of the given length
        for guess in itertools.product(characters, repeat=length):
            # Convert tuple of characters into a string
            guess_password = ''.join(guess)

            # Check if the guessed password matches the target password
            if guess_password == target_password:
                return guess_password
            else:
                print(guess_password)

# Call the brute-force function to find the password
cracked_password = brute_force_crack()

# End time after cracking the password
end_time = time.time()

# Show the result
if cracked_password:
    print(f"Password found: {cracked_password}")
else:
    print("Password not found.")

# Print the elapsed time
print(f"Time taken: {end_time - start_time:.2f} seconds")
