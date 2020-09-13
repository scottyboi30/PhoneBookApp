import React, { useState } from "react";
import { Formik, FieldArray, Form } from "formik";
import { useHistory } from "react-router-dom";

import api from "../../../api";
import CustomInput from './CustomInput';
import contactValidation from '../../../validation/contactValidation';

const initialValues = { contacts: [{ name: '', number: '' }] };
const contactsArrayErrors = errors =>
  typeof errors.contacts === 'string' ? <div className="badge badge-danger">{errors.contacts}</div> : null;

const badRequsetErrors = errors => {
  const errorList = Object.values(errors).flat();
  return errorList.length > 0 ?
  errorList.map(error => (
      <div className="badge badge-danger ml-2">{error}</div>
    ))
    : null;
}

const ContactsForm = () => {
  const history = useHistory();
  const [badRequest, setBadRequest] = useState([]);

  return (
    <div className="mt-3">
      <h1>Add Contacts</h1>
      <div>
        <Formik
          initialValues={initialValues}
          validationSchema={contactValidation}
          isInitialValid={contactValidation.isValidSync(initialValues)}
          onSubmit={async (values) => {
            try {
              await api.Contacts.create(values.contacts);
              history.push('/contacts');
            } catch (error) {
              setBadRequest(error.response.data.errors)
              console.log(error.response.data.errors);
            }
          }}
        >
          {({ values, isValid, errors }) => (
            <Form>
              <FieldArray
                name="contacts"
                render={(arrayHelpers) => (
                  <div>
                    {values.contacts.map((contact, index) => (
                      <div key={index}>
                        <div className="row mt-3">
                          <CustomInput name={`contacts.${index}.name`} placeholder="Name" />
                          <CustomInput name={`contacts.${index}.number`} placeholder="Number" />
                        </div>
                        {index === values.contacts.length - 1 && (
                          <div className="mt-3">
                            <button
                              className="btn btn-info w-25 mr-3"
                              type="button"
                              onClick={() =>
                                arrayHelpers.push({ name: "", number: "" })
                              }
                              disabled={!isValid}>
                              Add another contact
                          </button>
                            {values.contacts.length !== 1 && (
                              <button
                                className="btn btn-danger mr-5 w-25"
                                type="button"
                                onClick={() => arrayHelpers.remove(index)}
                              >
                                Remove
                              </button>
                            )}
                          </div>
                        )}
                      </div>
                    ))}
                    <div className="d-flex justify-content-end">
                      <button className="btn btn-primary mt-3 w-25" type="submit">
                        Save
                    </button>
                    </div>
                    <div className=" d-flex justify-content-end mt-3">
                      {contactsArrayErrors(errors)}
                      {badRequsetErrors(badRequest)}
                    </div>
                  </div>
                )}
              />
            </Form>
          )}
        </Formik>
      </div>
    </div>
  );
}

export default ContactsForm;
