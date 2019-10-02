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
        # if (p in subMap and subMap[p] != c) or c in subMap.viewvalues():
            # return False
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
    def impl(subMap, plaintextWords, i):
        if i == len(ciphertextWords):
            yield plaintextWords
            return
        c = ciphertextWords[i]
        uCode = calculateUniquenessCode(c)
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


def loadWords():
    d = {}
    try:
        with open("words_alpha.txt", "r") as f:
            words = f.read()
    except object:
        words = urllib2.urlopen("https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt").read()
    for w in words.splitlines():
        w = w.upper()
        uCode = calculateUniquenessCode(w)
        if uCode in d:
            d[uCode].append(w)
        else:
            d[uCode] = [w]
    return d


englishWords = loadWords()
print len(englishWords)


def crack(sentence):
    ciphertext_words = sentence.split(" ")
    return crackSubstitutionCipher(englishWords, ciphertext_words)


for x in crack("HUOOPUOHH DT HOBQQUO FOOQ FO BQ QSO BDRPMRQ"):
    print x
