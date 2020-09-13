import React from "react";
import { Field } from 'formik';

import ErrorMessage from './ErrorMessage';

const CustomInput = ({ name, placeholder }) => (
  <div className="col">
    <Field
      className="form-control"
      placeholder={placeholder}
      name={name}
    />
    <ErrorMessage name={name} />
  </div>
);

export default CustomInput;
