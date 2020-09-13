import * as Yup from 'yup';

const uniqueName = (contacts) => {
  const uniqueValues = new Set(contacts.map(c => c.name));
  return !(uniqueValues.size < contacts.length)
}

const contactValidation = Yup.object().shape({
  contacts: Yup.array()
    .of(
      Yup.object().shape({
        name: Yup.string()
          .required('Name is required')
          .matches(/^[A-Za-z\s]*$/, {message: 'Name cannot contain numbers or special characters', excludeEmptyString: true}),
        number: Yup.string()
          .required('Number is required')
          .matches(/^((\+[1-9]{1,3}(\(0\)|0)?)|0)\d{6,10}$/, {message: 'Please enter a valid number', excludeEmptyString: true}),
      })
    )
    .test(
      'is-unique-names',
      'cannot add duplicate contact names',
      uniqueName,
    ),
});

export default contactValidation;