import { observer } from 'mobx-react-lite';
import { Remark } from '../../../models/Remark';
import React from 'react';
import RemarkDetail from '../Detail/RemarkDetail';
import { Comment, Header } from 'semantic-ui-react';
import RemarkForm from '../Form/RemarkForm';

interface IRemarkList {
  remarks: Array<Remark>;
}

const RemarkList = ({ remarks }: IRemarkList) => {
  return (
    <Comment.Group>
      <Header as='h3' dividing>
        Comments
      </Header>
      {remarks.map((remark, index) => (
        <RemarkDetail remark={remark} key={`${remark.id}${index}`} />
      ))}
      <RemarkForm shoutId={remarks[0].shoutId} />
    </Comment.Group>
  );
};

export default observer(RemarkList);
