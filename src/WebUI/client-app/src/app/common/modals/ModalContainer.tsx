import { observer } from 'mobx-react-lite';
import React from 'react';
import { Modal } from 'semantic-ui-react';
import { useStore } from '../../stores/store';

export default observer(function ModalContainer() {
  const { modalStore } = useStore();
  const { closeModal } = modalStore;
  return (
    <Modal open={modalStore.modal.open} onClose={closeModal} size='tiny'>
      <Modal.Content>{modalStore.modal.body}</Modal.Content>
    </Modal>
  );
});
