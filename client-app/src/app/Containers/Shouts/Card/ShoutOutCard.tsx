import { observer } from 'mobx-react-lite';
import React, { useCallback } from 'react';
import { Link } from 'react-router-dom';
import { Button, Card } from 'semantic-ui-react';
import { Shout } from '../../../models/Shout';
import { useShoutStore } from '../../../stores/stores';
import RemarkList from '../../Remarks/List/RemarkList';
import VotesCard from './VotesCard';

interface IShoutOutCard {
  shout: Shout;
  isDetailCard?: boolean;
}

const ShoutOutCard = ({ shout, isDetailCard }: IShoutOutCard) => {
  const shoutStore = useShoutStore();

  const upVoteHandler = useCallback(async () => {
    shout.upVotes += 1;
    await shoutStore.editShout(shout);
    shoutStore.loadShouts();
  }, [shout, shoutStore]);

  const downVoteHandler = useCallback(async () => {
    shout.downVotes += 1;
    await shoutStore.editShout(shout);
    shoutStore.loadShouts();
  }, [shout, shoutStore]);

  return (
    <Card fluid>
      <Card.Content>
        <Card.Header>
          <Link to={`/shoutOuts/${shout.id}`}>{shout.body}</Link>
        </Card.Header>
        <Card.Description>
          <VotesCard
            label='Up Votes'
            icon='thumbs up outline'
            content={shout.upVotes}
            labelPosition='right'
          />
          <VotesCard
            label='Down Votes'
            icon='thumbs down outline'
            content={shout.downVotes}
            labelPosition='left'
          />
          <VotesCard
            label='Remarks'
            icon='comments outline'
            content={shout.remarks.length}
            labelPosition='left'
          />
          {isDetailCard && <RemarkList remarks={shout.remarks} />}
        </Card.Description>
      </Card.Content>
      <Card.Content extra>
        <div className='ui two buttons'>
          <Button primary inverted onClick={upVoteHandler}>
            Up Vote
          </Button>
          <Button secondary inverted onClick={downVoteHandler}>
            Down Vote
          </Button>
        </div>
      </Card.Content>
    </Card>
  );
};

export default observer(ShoutOutCard);
