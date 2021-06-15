import { LockOutlined, UserOutlined } from '@ant-design/icons';
import { Button, Space } from 'antd';
import { ErrorMessage, Formik } from 'formik';
import { Form, Input, ResetButton, SubmitButton } from 'formik-antd';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { Header, Label } from 'semantic-ui-react';
import CustomTextInput from '../../app/common/form/CustomTextInput';
import { useStore } from '../../app/stores/store';

export default observer(function LoginForm() {
  const { userStore } = useStore();

  return (
    <Formik
      initialValues={{ email: '', password: '', error: null }}
      onSubmit={(values, { setErrors }) =>
        userStore
          .login(values)
          .catch((error) => setErrors({ error: 'Invalid email or password' }))
      }
    >
      {({ handleSubmit, isSubmitting, errors }) => (
        <Form className="login-form" name="normal_login" onFinish={handleSubmit} autoComplete='off'>
          <Header
            as='h2'
            content='Login to ORRAS'
            color='blue'
            textAlign='center'
          />
          <Form.Item name='email'>
            <Input name='email' prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Username"/>
          </Form.Item>
          <Form.Item name='password'>
            <Input name='password' prefix={<LockOutlined className="site-form-item-icon" />} type="password" placeholder="Password"/>
          </Form.Item>

          <Form.Item name='forgotpasswordlink'>
          <a className="login-form-forgot" href="">
          Forgot password
        </a>
          </Form.Item>
          <Space>
          <Form.Item name='login-or-register'>
          <Button type="primary" htmlType="submit" className="login-form-button">
                Login
            </Button>
          </Form.Item>
            <Form.Item name='register'>
             Or <a href="">Register now</a>
          </Form.Item>
          </Space>
          

          <ErrorMessage
            name='error'
            render={() => (
              <Label
                style={{ marginBottom: 10 }}
                basic
                color='red'
                content={errors.error}
              />
            )}
          />
        </Form>
      )}
    </Formik>
  );
});
