import { observer } from 'mobx-react-lite';
import { Remark } from '../../../models/Remark';
import React from 'react';
import { Comment } from 'semantic-ui-react';

interface IRemarkDetail {
  remark: Remark;
}

const RemarkDetail = ({ remark }: IRemarkDetail) => {
  return (
    <Comment>
      <Comment.Avatar
        as='a'
        src='https://react.semantic-ui.com/images/avatar/small/joe.jpg'
      />
      <Comment.Content>
        <Comment.Author>{remark.body}</Comment.Author>
        <Comment.Metadata />
      </Comment.Content>
    </Comment>
  );
};

export default observer(RemarkDetail);
