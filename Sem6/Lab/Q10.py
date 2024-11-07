def caesar_encrypt(text, shift):
    encrypted = ""
    for char in text:
        if char.isalpha():
            # Shift character by shift amount
            char_code = ord(char) + shift
            # Handle wrap-around for upper case letters
            if char.isupper() and char_code > ord('Z'):
                char_code -= 26
            # Handle wrap-around for lower case letters
            elif char.islower() and char_code > ord('z'):
                char_code -= 26
            # Append encrypted character to result
            encrypted += chr(char_code)
        else:
            # Append non-alphabetic character as is
            encrypted += char
    return encrypted

text = input("Enter the text to be encrypted: ")
shift = int(input("Enter the shift amount: "))

encrypted_text = caesar_encrypt(text, shift)

print(f"Encrypted text: {encrypted_text}")
