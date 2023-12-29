import easyocr
from spellchecker import SpellChecker

def text_recognition(file_path, language):
    reader = easyocr.Reader(language)
    result = reader.readtext(file_path, detail = 0, paragraph=True, min_size=5)
    return result

def interlist(n):
    file_path = []
    for i in range (int(n)):
        item = input("i: ")
        item = item +".jpg"
        file_path.append(item)
    return file_path

def spellcheck(string):
    spell = SpellChecker(language = 'ru')
    string2 = string.split()
    string = ""
    for word in string2:
        word2 = spell.correction(word)
        if (word2 != None):  
            string = string + " " + word2
        else:
            string = string + " " + word
    return string

def main():
    file_path = interlist(input("Photo count: "))   
    language = input("Enter lang: ").split()   
    list = []
    for item in file_path:
        for item in text_recognition(item, language=language):  
                list.append(spellcheck(item))
    f = open('result.txt', 'w')
    for item in list:
        f.write("%s\n" % item)
    print()
    
if __name__ == "__main__":
    while (True):
        main()
    
