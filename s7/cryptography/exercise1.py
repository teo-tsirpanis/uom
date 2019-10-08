# University of Macedonia,
# Department of Applied Informatics,
# Semester 7,
# Cryptography,
# Assignment 1

# Created by: Theodore Tsirpanis
# Professor: Sofia Petridou

import urllib2

numberOfLetters = 26


def normalizeChar(c):
    return ord(c.upper()) - ord('A')


def denormalizeChar(x):
    return chr(x + ord('A'))


def calculateUniquenessCode(s):
    xs = []
    d = {}
    for c in s:
        c = normalizeChar(c)
        if c not in d:
            d[c] = len(d)
        xs.append(d[c])
    return tuple(xs)


def couldHaveBeen(subMap, possiblePlaintext, ciphertext):
    if len(possiblePlaintext) != len(ciphertext):
        return False
    for i in range(len(possiblePlaintext)):
        p = normalizeChar(possiblePlaintext[i])
        c = normalizeChar(ciphertext[i])
        if p in subMap:
            if subMap[p] != c:
                return False
        else:
            if c in subMap.viewvalues():
                return False
    return True


def generateSubMap(plainText, ciphertext):
    d = {}
    for i in range(len(plainText)):
        d[normalizeChar(plainText[i])] = normalizeChar(ciphertext[i])
    return d


def mergeDictionaries(dest, source):
    dest = dest.copy()
    dest.update(source)
    return dest


def crackSubstitutionCipher(dictionary, ciphertextWords):
    uCodes = map(calculateUniquenessCode, ciphertextWords)

    def impl(subMap, plaintextWords, i):
        if i == len(ciphertextWords):
            yield plaintextWords
            return
        c = ciphertextWords[i]
        uCode = uCodes[i]
        possiblePlaintextWords = filter(lambda p: couldHaveBeen(subMap, p, c),
                                        dictionary[uCode] if uCode in dictionary else [])
        for pNew in possiblePlaintextWords:
            possibleSubMap = mergeDictionaries(subMap, generateSubMap(pNew, c))
            for x in impl(possibleSubMap, plaintextWords + (pNew,), i + 1):
                yield x
    result = []
    for x in impl({}, (), 0):
        result.append(" ".join(x))
    return result


def loadUrl(url, cachedPath):
    # These files are big, so we can save
    # bandwidth by caching them in a file.
    try:
        with open(cachedPath, "r") as f:
            return f.read()
    except object:
        return urllib2.urlopen(url).read()


def loadWords():
    d = {}
    words = loadUrl("https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt", "words_alpha.txt")
    for w in words.splitlines():
        w = w.upper()
        uCode = calculateUniquenessCode(w)
        if uCode in d:
            d[uCode].append(w)
        else:
            d[uCode] = [w]
    return d


def calculateLetterFrequency():
    d = {}
    text = loadUrl("http://www.gutenberg.org/cache/epub/1404/pg1404.txt", "pg1404.txt")
    for x in text:
        x = x.upper()
        if x.isalpha():
            if x in d:
                d[x] = d[x] + 1
            else:
                d[x] = 1
    return d


def crack(dictionary, sentence):
    words = filter(lambda w: w.isalpha() or w == " ", sentence).split(" ")
    return crackSubstitutionCipher(dictionary, words)


def pickMostLikely(letterFrequency, lengthOfResults, sentences):
    # We will sort them so that the most likely plaintext comes last.
    # This way, the user will see it without scrolling up.
    def getFrequencyScore(sentence):
        i = 0
        for c in sentence:
            if c in letterFrequency:
                i += letterFrequency[c]
        return i
    sortedSentences = sorted(sentences, key=getFrequencyScore)
    return sortedSentences[-lengthOfResults:]


if __name__ == '__main__':
    print "This is a cracker of Substitution Ciphers."
    print "Written by Theodore Tsirpanis (dai19090)."
    englishWords = loadWords()
    lengthOfResults = 75
    print "Powered by a dictionary of {0} English words.".format(len(englishWords))
    print "\nBut first, let's talk about letter frequencies in English text."
    print "As an example, we will take the 85 Federalist Papers."
    letterFrequency = calculateLetterFrequency()
    for x in range(ord("A"), ord("Z") + 1):
        c = chr(x)
        print "{0} appears {1} time(s)".format(c, letterFrequency[c] if c in letterFrequency else 0)
    print ""
    while True:
        sentence = raw_input("Please enter your encrypted English sentence to crack (only ASCII letters): ")
        if not sentence:
            break
        possiblePlaintext = crack(englishWords, sentence)

        if possiblePlaintext:
            if sentence[0] == " ":
                possiblePlaintextFiltered = possiblePlaintext
            else:
                possiblePlaintextFiltered = pickMostLikely(letterFrequency, lengthOfResults, possiblePlaintext)
            print "'{0}' can be decoded into something of these:".format(sentence)
            for p in possiblePlaintextFiltered:
                print "* {0}".format(p)
            if len(possiblePlaintextFiltered) != len(possiblePlaintext):
                print "Some results are omitted. Only the {0} sentences with the most common letters are shown".format(lengthOfResults)
                print "If you want to display all results, add a space before yor ciphertext."
        else:
            print "Unfortunately, '{0}' cannot be decoded".format(sentence)
