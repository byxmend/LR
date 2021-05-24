document.addEventListener('DOMContentLoaded', () => {
  let phoneInputs = document.querySelectorAll('input[data-tel-input]')

  let getInputNumbersValue = (input) => {
    // Return stripped input value — just numbers
    return input.value.replace(/\D/g, '')
  }

  let onPhonePaste = (e) => {
    let input = e.target,
      inputNumbersValue = getInputNumbersValue(input)
    let pasted = e.clipboardData || window.clipboardData

    if (pasted) {
      let pastedText = pasted.getData('Text')

      if (/\D/g.test(pastedText)) {
        // Attempt to paste non-numeric symbol — remove all non-numeric symbols,
        // formatting will be in onPhoneInput handler
        input.value = inputNumbersValue
        return
      }
    }
  }

  let onPhoneInput = (e) => {
    let input = e.target,
      inputNumbersValue = getInputNumbersValue(input),
      selectionStart = input.selectionStart,
      formattedInputValue = ''

    if (!inputNumbersValue) {
      return (input.value = '')
    }

    if (input.value.length != selectionStart) {
      // Editing in the middle of input, not last symbol
      if (e.data && /\D/g.test(e.data)) {
        // Attempt to input non-numeric symbol
        input.value = inputNumbersValue
      }
      return
    }

    if (['3', '8'].indexOf(inputNumbersValue[0]) > -1) {
      let firstSymbols = inputNumbersValue[0] == '8' ? '8' : '+3'
      formattedInputValue = input.value = firstSymbols + ' '

      if (inputNumbersValue[0] == '8') {
        // 8 (0**) ***-**-**
        let firstSymbols = (inputNumbersValue[0] = '8')
        formattedInputValue = input.value = firstSymbols + ' '

        if (inputNumbersValue.length > 1 && inputNumbersValue[1] == '0') {
          formattedInputValue += '(' + inputNumbersValue.substring(1, 4)
        }
        if (inputNumbersValue.length >= 4) {
          formattedInputValue += ') ' + inputNumbersValue.substring(4, 7)
        }
        if (inputNumbersValue.length >= 7) {
          formattedInputValue += ' ' + inputNumbersValue.substring(7, 9)
        }
        if (inputNumbersValue.length >= 9) {
          formattedInputValue += ' ' + inputNumbersValue.substring(9, 11)
        }
      } else if (inputNumbersValue[0] == '3') {
        // +375 (**) ***-**-**
        let firstSymbols = '+375'
        formattedInputValue = input.value = firstSymbols + ' '

        if (
          inputNumbersValue.length > 3 &&
          inputNumbersValue[3] != '7' &&
          inputNumbersValue[3] != '5'
        ) {
          formattedInputValue += '(' + inputNumbersValue.substring(3, 5)
        }

        if (inputNumbersValue.length >= 5) {
          formattedInputValue += ') ' + inputNumbersValue.substring(5, 8)
        }
        if (inputNumbersValue.length >= 8) {
          formattedInputValue += ' ' + inputNumbersValue.substring(8, 10)
        }
        if (inputNumbersValue.length >= 10) {
          formattedInputValue += ' ' + inputNumbersValue.substring(10, 12)
        }
      }
    } else {
      // Other numbers without mask
      formattedInputValue = '+' + inputNumbersValue.substring(0, 18)
    }
    input.value = formattedInputValue
  }

  let onPhoneKeyDown = (e) => {
    // Clear input after remove last symbol
    let inputValue = e.target.value.replace(/\D/g, '')

    // e.keyCode = 8 = backspace
    if (e.keyCode == 8 && inputValue.length == 1) {
      e.target.value = ''
    }
  }

  for (let phoneInput of phoneInputs) {
    phoneInput.addEventListener('keydown', onPhoneKeyDown)
    phoneInput.addEventListener('input', onPhoneInput, false)
    phoneInput.addEventListener('paste', onPhonePaste, false)
  }
})
